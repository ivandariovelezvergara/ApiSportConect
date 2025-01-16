using BSportConect.Master;
using Entity.Service;
using Microsoft.AspNetCore.Mvc;
using Entity.Service.Master;
using APISportConnect.Filter;

namespace APISportConnect.Controllers
{
    
    [ApiController]
    [Authorizes("settings")]
    public class ParameterController : ControllerBase
    {
        private readonly IParameterService _service;

        public ParameterController(IParameterService service)
        {
            _service = service;
        }

        #region GetAllParameter
        [HttpGet]
        [Route("api/Parameter/GetAll")]
        public async Task<IActionResult> GetAllParameter()
        {
            BaseResponse response;
            List<MasterTableResponse> listParameter;
            try
            {
                listParameter = await _service.GetAllParametersAsync();
                return Ok(listParameter);
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

        #region GetParametersDetailId
        [HttpGet]
        [Route("api/Parameter/GetParametersDetailId/{id}")]
        public async Task<IActionResult> GetParametersDetailId(string id)
        {
            BaseResponse response;
            List<ParametersDetailResponse> listParameter;
            try
            {
                listParameter = await _service.GetParametersDetailIdAsync(id);
                return Ok(listParameter);
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

        #region GetParametersDetailName
        [HttpGet]
        [Route("api/Parameter/GetParametersDetailNameAsync/{masterName}")]
        public async Task<IActionResult> GetParametersDetailName(string masterName)
        {
            BaseResponse response;
            List<ParametersDetailResponse> listParameter;
            try
            {
                listParameter = await _service.GetParametersDetailNameAsync(masterName);
                return Ok(listParameter);
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

        #region CreateParameter
        [HttpPost]
        [Route("api/Parameter/Create")]
        public async Task<IActionResult> CreateParameter([FromBody] MasterTableRequest master)
        {
            BaseResponse response;
            try
            {
                response = await _service.CreateParameterAsync(master);
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

        #region AddParameterDetail
        [HttpPost]
        [Route("api/Parameter/AddParameterDetail/{masterId}")]
        public async Task<IActionResult> AddParameterDetail(string masterId, [FromBody] MasterParameterRequest newParameter)
        {
            BaseResponse response;
            try
            {
                response = await _service.AddParameterDetailAsync(Guid.Parse(masterId), newParameter);
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

        #region UpdateParameterDetail
        [HttpPut]
        [Route("api/Parameter/UpdateParameterDetail/{masterId}/{parameterId}")]
        public async Task<IActionResult> UpdateParameterDetail(string masterId, string parameterId, [FromBody] MasterParameterRequest newParameter)
        {
            BaseResponse response;
            try
            {
                response = await _service.UpdateParameterDetailAsync(Guid.Parse(masterId), Guid.Parse(parameterId), newParameter);
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

        #region DeleteAppObjectAsync
        [HttpDelete()]
        [Route("api/Parameter/DeleteParameterDetail/{masterId}/{parameterId}")]

        public async Task<IActionResult> DeleteParameterDetail(string masterId, string parameterId)
        {
            await _service.DeleteParameterDetailAsync(Guid.Parse(masterId), Guid.Parse(parameterId));
            return NoContent();
        }
        #endregion
    }
}
