using DSportConnect.Models.Master;
using DSportConnect.Models.Security;
using Entity.Service.Master;
using Entity.Service.Security;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.Reflection.Metadata;
using System.Xml;

namespace DSportConnect.Repositories.Master
{
    public class ParameterRepository : IParameterRepository
    {
        private readonly IMongoCollection<MasterTable> _parameterCollection;

        public ParameterRepository(IMongoClient mongoClient, string databaseName)
        {
            var database = mongoClient.GetDatabase(databaseName);
            _parameterCollection = database.GetCollection<MasterTable>("Parameters");
        }

        #region GetAllParametersAsync
        public async Task<List<MasterTableResponse>> GetAllParametersAsync()
        {
            List<MasterTableResponse> masterResponses = new List<MasterTableResponse>();
            List<MasterTable> list = await _parameterCollection.Find(_ => true).ToListAsync();
            if (list.Count < 1)
                return masterResponses;
            foreach (MasterTable _master in list)
            {
                MasterTableResponse masterGet = new MasterTableResponse
                {
                    Id = _master.Id,
                    MasterName = _master.MasterName
                };
                masterResponses.Add(masterGet);
            }
            return masterResponses;
        }
        #endregion

        #region GetParametersDetailIdAsync
        public async Task<List<ParametersDetailResponse>> GetParametersDetailIdAsync(string id)
        {
            List<ParametersDetailResponse> parametersGet = new List<ParametersDetailResponse>();
            var projection = Builders<MasterTable>.Projection.Expression(m => m.Parameters);
            List<Models.Master.MasterParameter> _parameters = await _parameterCollection.Find(r => r.Id == Guid.Parse(id)).Project(projection).FirstOrDefaultAsync();
            if (_parameters == null)
                return parametersGet;
            foreach (var item in _parameters)
            {
                ParametersDetailResponse parametersDetail = new ParametersDetailResponse()
                {
                    Id = item.Id,
                    Code = item.Code,
                    Diminutive = item.Diminutive,
                    IdFather = item.IdFather,
                    Name = item.Name
                };
                parametersGet.Add(parametersDetail);
            }
            return parametersGet;
        }
        #endregion

        #region GetParametersDetailNameAsync
        public async Task<List<ParametersDetailResponse>> GetParametersDetailNameAsync(string masterName)
        {
            List<ParametersDetailResponse> parametersGet = new List<ParametersDetailResponse>();
            var projection = Builders<MasterTable>.Projection.Expression(m => m.Parameters);
            List<Models.Master.MasterParameter> _parameters = await _parameterCollection.Find(r => r.MasterName == masterName).Project(projection).FirstOrDefaultAsync();
            if (_parameters == null)
                return parametersGet;
            foreach (var item in _parameters)
            {
                ParametersDetailResponse parametersDetail = new ParametersDetailResponse()
                {
                    Id = item.Id,
                    Code = item.Code,
                    Diminutive = item.Diminutive,
                    IdFather = item.IdFather,
                    Name = item.Name
                };
                parametersGet.Add(parametersDetail);
            }
            return parametersGet;
        }
        #endregion

        #region CreateParameterAsync
        public async Task CreateParameterAsync(MasterTableRequest master)
        {
            MasterTable _master = new MasterTable
            {
                Id = Guid.NewGuid(),
                MasterName = master.MasterName
            };
            foreach (var item in master.Parameters)
            {
                Models.Master.MasterParameter masterParameter = new Models.Master.MasterParameter()
                {
                    Id = Guid.NewGuid(),
                    Name = item.Name,
                    Code = item.Code,
                    Diminutive = item.Diminutive,
                    IdFather = item.IdFather
                };
                _master.Parameters.Add(masterParameter);
            }
            await _parameterCollection.InsertOneAsync(_master);
        }
        #endregion

        #region AddParameterDetailAsync
        public async Task<bool> AddParameterDetailAsync(Guid masterId, MasterParameterRequest newParameter)
        {
            MasterParameter masterParameter = new MasterParameter()
            {
                Id= Guid.NewGuid(),
                Name = newParameter.Name,
                Code = newParameter.Code,
                Diminutive = newParameter.Diminutive,
                IdFather = newParameter.IdFather
            };

            var update = Builders<MasterTable>.Update.Push(m => m.Parameters, masterParameter);
            var result = await _parameterCollection.UpdateOneAsync(m => m.Id == masterId, update);
            return result.ModifiedCount > 0;
        }
        #endregion

        #region UpdateParameterDetailAsync
        public async Task<bool> UpdateParameterDetailAsync(Guid masterId, Guid parameterId, MasterParameterRequest newParameter)
        {
            MasterParameter masterParameter = new MasterParameter()
            {
                Id = parameterId,
                Name = newParameter.Name,
                Code = newParameter.Code,
                Diminutive = newParameter.Diminutive,
                IdFather = newParameter.IdFather
            };

            var filter = Builders<MasterTable>.Filter.And(
                    Builders<MasterTable>.Filter.Eq(m => m.Id, masterId),
                    Builders<MasterTable>.Filter.ElemMatch(m => m.Parameters, p => p.Id == parameterId));

            var update = Builders<MasterTable>.Update.Set("parameters.$", masterParameter);

            //var filter = Builders<MasterTable>.Filter.And(
            //    Builders<MasterTable>.Filter.Eq(m => m.Id, masterId),
            //    Builders<MasterTable>.Filter.ElemMatch(m => m.Parameters, p => p.Id == masterParameter.Id)
            //);

            //var update = Builders<MasterTable>.Update.Set(m => m.Parameters[-1], masterParameter);
            var result = await _parameterCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }
        #endregion

        #region DeleteParameterDetailAsync
        public async Task<bool> DeleteParameterDetailAsync(Guid masterId, Guid parameterId)
        {
            var update = Builders<MasterTable>.Update.PullFilter(
                m => m.Parameters,
                p => p.Id == parameterId
            );

            var result = await _parameterCollection.UpdateOneAsync(m => m.Id == masterId, update);
            return result.ModifiedCount > 0;
        }
        #endregion
    }
}
