using BSportConect.Sport;
using Entity.Service;
using Microsoft.AspNetCore.Mvc;
using Entity.Service.Sport;
using Entity.Enumerable;
using APISportConnect.Filter;

namespace APISportConnect.Controllers
{
    [ApiController]
    [Authorizes("settings")]
    public class SportController : ControllerBase
    {
        private readonly ISportService _service;

        public SportController(ISportService service)
        {
            _service = service;
        }

        #region GetAll
        [HttpGet]
        [Route("api/Sport/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            BaseResponse response;
            List<SportResponse> listSport;
            try
            {
                listSport = await _service.GetAllSportsAsync();
                return Ok(listSport);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion

        #region GetDetailId
        [HttpGet]
        [Route("api/Sport/GetDetailId/{id}")]
        public async Task<IActionResult> GetDetailId(string id)
        {
            BaseResponse response;
            SportResponse sport;
            try
            {
                sport = await _service.GetSportIdAsync(id);
                return Ok(sport);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion

        #region GetDetailName
        [HttpGet]
        [Route("api/Sport/GetDetailName/{name}")]
        public async Task<IActionResult> GetDetailName(string name)
        {
            BaseResponse response;
            SportResponse sport;
            try
            {
                sport = await _service.GetSportNameAsync(name);
                return Ok(sport);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion

        #region Create
        [HttpPost]
        [Route("api/Sport/Create")]
        public async Task<IActionResult> Create([FromBody] SportInformationRequest sport)
        {
            BaseResponse response;
            try
            {
                response = await _service.CreateSportAsync(sport);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 400,
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion

        #region UpdateDetail
        [HttpPut]
        [Route("api/Sport/UpdateStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateStatus(string id, bool status)
        {
            BaseResponse response;
            try
            {
                response = await _service.UpdateStatusSportAsync(Guid.Parse(id), status);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 400,
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion

        #region AddEvaluation
        [HttpPost]
        [Route("api/Sport/AddEvaluation/{id}/{type}")]
        public async Task<IActionResult> AddEvaluation(string id, EnumEvaluation type, [FromBody] EvaluationRequest newEvaluation)
        {
            BaseResponse response;
            try
            {
                response = await _service.AddSportDetailAsync(Guid.Parse(id), type, newEvaluation);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 400,
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion

        #region UpdateEvaluation
        [HttpPut]
        [Route("api/Sport/UpdateEvaluation/{id}/{type}/{evaluationId}")]
        public async Task<IActionResult> UpdateEvaluation(string id, EnumEvaluation type, string evaluationId, EvaluationRequest newEvaluation)
        {
            BaseResponse response;
            try
            {
                response = await _service.UpdateSportDetailAsync(Guid.Parse(id), type, Guid.Parse(evaluationId), newEvaluation);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 400,
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion

        #region DeleteEvaluation
        [HttpDelete()]
        [Route("api/Sport/DeleteEvaluation/{id}/{type}/{evaluationId}")]

        public async Task<IActionResult> DeleteEvaluation(string id, EnumEvaluation type, string evaluationId)
        {
            await _service.DeleteSportDetailAsync(Guid.Parse(id), type, Guid.Parse(evaluationId));
            return NoContent();
        }
        #endregion

        #region AddCategory
        [HttpPost]
        [Route("api/Sport/AddSportCategory/{id}")]
        public async Task<IActionResult> AddCategory(string id, CategoryRequest newCategory)
        {
            BaseResponse response;
            try
            {
                response = await _service.AddSportCategoryAsync(Guid.Parse(id), newCategory);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 400,
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion

        #region UpdateCategory
        [HttpPut]
        [Route("api/Sport/UpdateCategory/{id}/{categoryId}")]
        public async Task<IActionResult> UpdateCategory(string id, string categoryId, CategoryRequest newCategory)
        {
            BaseResponse response;
            try
            {
                response = await _service.UpdateSportCategoryAsync(Guid.Parse(id), Guid.Parse(categoryId), newCategory);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 400,
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion

        #region Deletecategory
        [HttpDelete()]
        [Route("api/Sport/Deletecategory/{id}/{categoryId}")]

        public async Task<IActionResult> Deletecategory(string id, string categoryId)
        {
            await _service.DeleteSportCategoryAsync(Guid.Parse(id), Guid.Parse(categoryId));
            return NoContent();
        }
        #endregion

        #region AddPosition
        [HttpPost]
        [Route("api/Sport/AddPosition/{id}")]
        public async Task<IActionResult> AddPosition(string id, PositionRequest newPosition)
        {
            BaseResponse response;
            try
            {
                response = await _service.AddPositionAsync(Guid.Parse(id), newPosition);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 400,
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion

        #region UpdatePosition
        [HttpPut]
        [Route("api/Sport/UpdatePosition/{id}/{positionId}")]
        public async Task<IActionResult> UpdatePosition(string id, string positionId, PositionRequest newPosition)
        {
            BaseResponse response;
            try
            {
                response = await _service.UpdatePositionAsync(Guid.Parse(id), Guid.Parse(positionId), newPosition);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 400,
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion

        #region DeletePosition
        [HttpDelete()]
        [Route("api/Sport/DeletePosition/{id}/{positionId}")]

        public async Task<IActionResult> DeletePosition(string id, string positionId)
        {
            await _service.DeletePositionAsync(Guid.Parse(id), Guid.Parse(positionId));
            return NoContent();
        }
        #endregion
    }
}
