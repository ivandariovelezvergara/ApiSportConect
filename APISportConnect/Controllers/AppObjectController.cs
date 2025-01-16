using BSportConect.Security;
using Entity.Service.Security;
using Entity.Service;
using Microsoft.AspNetCore.Mvc;
using APISportConnect.Filter;
using Entity.AppSettings;
using Microsoft.Extensions.Options;

namespace APISportConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorizes("settings")]
    public class AppObjectController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IAppObjectService _service;

        public AppObjectController(IOptions<JwtSettings> jwtOptions, IAppObjectService service)
        {
            _jwtSettings = jwtOptions.Value;
            _service = service;
        }

        #region GetAllObject
        [HttpGet()]
        public async Task<IActionResult> GetAllObject()
        {
            BaseResponse response;
            List<AppObjectResponse> listRol;
            try
            {
                listRol = await _service.GetAllAppObjectAsync();
                return Ok(listRol);
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

        #region GetObjectById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetObjectById(string id)
        {
            BaseResponse response;
            try
            {
                var obj = await _service.GetAppObjectByIdAsync(id);
                if (obj == null)
                {
                    response = new BaseResponse
                    {
                        IdStaus = 400,
                        Message = "El elemento no se encuentra registrado en la base de datos.",
                        IsError = true
                    };
                    return BadRequest(response);
                }
                else
                {
                    return Ok(obj);
                }
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

        #region CreateAppObjectAsync
        [HttpPost]
        public async Task<IActionResult> CreateAppObjectAsync([FromBody] AppObjectRequest obj)
        {
            BaseResponse response;
            try
            {
                response = await _service.CreateAppObjectAsync(obj);
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

        #region UpdateAppObjectAsync
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppObjectAsync(string id, [FromBody] AppObjectRequest obj)
        {
            BaseResponse response;
            try
            {
                response = await _service.UpdateAppObjectAsync(id, obj);
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppObjectAsync(string id)
        {
            await _service.DeleteAppObjectAsync(id);
            return NoContent();
        }
        #endregion
    }
}
