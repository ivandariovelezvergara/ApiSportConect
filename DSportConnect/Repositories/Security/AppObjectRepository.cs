using DSportConnect.Models.Security;
using Entity.Service.Security;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSportConnect.Repositories.Security
{
    public class AppObjectRepository : IAppObjectRepository
    {
        private readonly IMongoCollection<AppObject> _appObjCollection;

        public AppObjectRepository(IMongoClient mongoClient, string databaseName)
        {
            var database = mongoClient.GetDatabase(databaseName);
            _appObjCollection = database.GetCollection<AppObject>("AppObjects");
        }

        #region GetAllAppObjectAsync
        public async Task<List<AppObjectResponse>> GetAllAppObjectAsync()
        {
            List<AppObjectResponse> appObjResponses = new List<AppObjectResponse>();
            List<AppObject> list = await _appObjCollection.Find(_ => true).ToListAsync();
            if (list.Count < 1)
                return appObjResponses;
            foreach (AppObject _obj in list)
            {
                AppObjectResponse objGet = new AppObjectResponse
                {
                    Id = _obj.Id,
                    ObjectName = _obj.ObjectName,
                    Description = _obj.Description,
                    CreatedAt = _obj.CreatedAt
                };
                appObjResponses.Add(objGet);
            }
            return appObjResponses;
        }
        #endregion

        #region GetAppObjectByIdAsync
        public async Task<AppObjectResponse?> GetAppObjectByIdAsync(string id)
        {
            AppObject? _obj = await _appObjCollection.Find(r => r.Id == Guid.Parse(id)).FirstOrDefaultAsync();
            if (_obj == null)
                return null;
            AppObjectResponse objGet = new AppObjectResponse
            {
                Id = _obj.Id,
                ObjectName = _obj.ObjectName,
                Description = _obj.Description,
                CreatedAt = _obj.CreatedAt
            };
            return objGet;
        }
        #endregion

        #region GetAppObjectByNameAsync
        public async Task<AppObjectResponse?> GetAppObjectByNameAsync(string objectName)
        {
            AppObject? _obj = await _appObjCollection.Find(r => r.ObjectName == objectName).FirstOrDefaultAsync();
            if (_obj == null)
                return null;
            AppObjectResponse objGet = new AppObjectResponse
            {
                Id = _obj.Id,
                ObjectName = _obj.ObjectName,
                Description = _obj.Description,
                CreatedAt = _obj.CreatedAt
            };
            return objGet;
        }
        #endregion

        #region CreateAppObjectAsync
        public async Task CreateAppObjectAsync(AppObjectRequest obj)
        {
            AppObject _obj = new AppObject
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Description = obj.Description,
                ObjectName = obj.ObjectName
            };
            await _appObjCollection.InsertOneAsync(_obj);
        }
        #endregion

        #region UpdateAppObjectAsync
        public async Task UpdateAppObjectAsync(string id, AppObjectRequest obj)
        {
            AppObject _obj = new AppObject
            {
                Id = Guid.Parse(id),
                CreatedAt = DateTime.UtcNow,
                Description = obj.Description,
                ObjectName = obj.ObjectName
            };
            await _appObjCollection.ReplaceOneAsync(r => r.Id == Guid.Parse(id), _obj);
        }
        #endregion

        #region DeleteAppObjectAsync
        public async Task DeleteAppObjectAsync(string id) =>
            await _appObjCollection.DeleteOneAsync(r => r.Id == Guid.Parse(id));
        #endregion
    }
}
