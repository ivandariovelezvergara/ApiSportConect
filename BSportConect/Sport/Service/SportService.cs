using DSportConnect.Models.Sport;
using DSportConnect.Repositories.Sport;
using Entity.Enumerable;
using Entity.Service;
using Entity.Service.Master;
using Entity.Service.Sport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSportConect.Sport.Service
{
    public class SportService : ISportService
    {
        private readonly ISportRepository _repository;

        public SportService(ISportRepository repository)
        {
            _repository = repository;
        }

        #region GetAllSportsAsync
        public Task<List<SportResponse>> GetAllSportsAsync() => _repository.GetAllSportsAsync();
        #endregion

        #region GetSportIdAsync
        public Task<SportResponse> GetSportIdAsync(string id) => _repository.GetSportIdAsync(id);
        #endregion

        #region GetSportNameAsync
        public Task<SportResponse> GetSportNameAsync(string name) => _repository.GetSportNameAsync(name);
        #endregion

        #region CreateSportAsync
        public async Task<BaseResponse> CreateSportAsync(SportInformationRequest sport)
        {
            if (string.IsNullOrWhiteSpace(sport.Name))
                throw new ArgumentException("El campo Name no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(sport.Description))
                throw new ArgumentException("El campo Description no puede estar vacío.");

            _repository.CreateSportAsync(sport);

            return new BaseResponse
            {
                IdStaus = 200,
                IsError = false,
                Message = "La información se ha almacenado correctamente."
            };
        }
        #endregion

        #region UpdateParameterDetailAsync
        public async Task<BaseResponse> UpdateStatusSportAsync(Guid id, bool status)
        {
            bool result = await _repository.UpdateStatusSportAsync(id, status);
            if (result)
            {
                return new BaseResponse
                {
                    IdStaus = 200,
                    IsError = false,
                    Message = "La información se ha editado correctamente."
                };
            }
            else
            {
                throw new ArgumentException("No encontro informacion del deporte para editar.");
            }
        }
        #endregion

        #region AddSportDetailAsync
        public async Task<BaseResponse> AddSportDetailAsync(Guid id, EnumEvaluation type, EvaluationRequest newEvaluation)
        {
            bool result = await _repository.AddSportDetailAsync(id, type, newEvaluation);
            if (result)
            {
                return new BaseResponse
                {
                    IdStaus = 200,
                    IsError = false,
                    Message = "La información se ha agregado correctamente."
                };
            }
            else
            {
                throw new ArgumentException("No encontro información del deporte para editar.");
            }
        }
        #endregion

        #region UpdateSportDetailAsync
        public async Task<BaseResponse> UpdateSportDetailAsync(Guid id, EnumEvaluation type, Guid evaluationId, EvaluationRequest newEvaluation)
        {
            bool result = await _repository.UpdateSportDetailAsync(id, type, evaluationId, newEvaluation);
            if (result)
            {
                return new BaseResponse
                {
                    IdStaus = 200,
                    IsError = false,
                    Message = "La información se ha editado correctamente."
                };
            }
            else
            {
                throw new ArgumentException("No encontro información del deporte para editar.");
            }
        }
        #endregion

        #region DeleteSportDetailAsync
        public async Task<BaseResponse> DeleteSportDetailAsync(Guid id, EnumEvaluation type, Guid evaluationId)
        {
            bool result = await _repository.DeleteSportDetailAsync(id, type, evaluationId);
            if (result)
            {
                return new BaseResponse
                {
                    IdStaus = 200,
                    IsError = false,
                    Message = "La información se ha editado correctamente."
                };
            }
            else
            {
                throw new ArgumentException("No encontro información del deporte para editar.");
            }
        }
        #endregion

        #region AddSportCategoryAsync
        public async Task<BaseResponse> AddSportCategoryAsync(Guid id, CategoryRequest newCategory)
        {
            bool result = await _repository.AddSportCategoryAsync(id, newCategory);
            if (result)
            {
                return new BaseResponse
                {
                    IdStaus = 200,
                    IsError = false,
                    Message = "La información se ha agregado correctamente."
                };
            }
            else
            {
                throw new ArgumentException("No encontro información del deporte para editar.");
            }
        }
        #endregion

        #region UpdateSportCategoryAsync
        public async Task<BaseResponse> UpdateSportCategoryAsync(Guid id, Guid categoryId, CategoryRequest newCategory)
        {
            bool result = await _repository.UpdateSportCategoryAsync(id, categoryId, newCategory);
            if (result)
            {
                return new BaseResponse
                {
                    IdStaus = 200,
                    IsError = false,
                    Message = "La información se ha editado correctamente."
                };
            }
            else
            {
                throw new ArgumentException("No encontro información del deporte para editar.");
            }
        }
        #endregion

        #region DeleteSportCategoryAsync
        public async Task<BaseResponse> DeleteSportCategoryAsync(Guid id, Guid categoryId)
        {
            bool result = await _repository.DeleteSportCategoryAsync(id, categoryId);
            if (result)
            {
                return new BaseResponse
                {
                    IdStaus = 200,
                    IsError = false,
                    Message = "La información se ha editado correctamente."
                };
            }
            else
            {
                throw new ArgumentException("No encontro información del deporte para editar.");
            }
        }
        #endregion

        #region AddPositionAsync
        public async Task<BaseResponse> AddPositionAsync(Guid id, PositionRequest newPosition)
        {
            bool result = await _repository.AddPositionAsync(id, newPosition);
            if (result)
            {
                return new BaseResponse
                {
                    IdStaus = 200,
                    IsError = false,
                    Message = "La información se ha agregado correctamente."
                };
            }
            else
            {
                throw new ArgumentException("No encontro información del deporte para editar.");
            }
        }
        #endregion

        #region UpdatePositionAsync
        public async Task<BaseResponse> UpdatePositionAsync(Guid id, Guid positionId, PositionRequest newPosition)
        {
            bool result = await _repository.UpdatePositionAsync(id, positionId, newPosition);
            if (result)
            {
                return new BaseResponse
                {
                    IdStaus = 200,
                    IsError = false,
                    Message = "La información se ha editado correctamente."
                };
            }
            else
            {
                throw new ArgumentException("No encontro información del deporte para editar.");
            }
        }
        #endregion

        #region DeletePositionAsync
        public async Task<BaseResponse> DeletePositionAsync(Guid id, Guid positionId)
        {
            bool result = await _repository.DeletePositionAsync(id, positionId);
            if (result)
            {
                return new BaseResponse
                {
                    IdStaus = 200,
                    IsError = false,
                    Message = "La información se ha editado correctamente."
                };
            }
            else
            {
                throw new ArgumentException("No encontro información del deporte para editar.");
            }
        }
        #endregion
    }
}
