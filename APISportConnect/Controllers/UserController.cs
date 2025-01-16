using Entity.Service.Sport;
using Entity.Service;
using Microsoft.AspNetCore.Mvc;
using BSportConect.Sport;
using BSportConect.User;
using Entity.Service.User;
using APISportConnect.Filter;
using Microsoft.AspNetCore.Authorization;

namespace APISportConnect.Controllers
{
    [ApiController]
    //[Authorizes("principal")]
    public class UserController : ControllerBase
    {
        private readonly IInformationService _service;

        public UserController(IInformationService service)
        {
            _service = service;
        }

        #region Create
        [HttpPost]
        [Route("api/User/Create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest user)
        {
            BaseResponse response;
            try
            {
                response = await _service.CreateUserAsync(user);
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
    }
}
