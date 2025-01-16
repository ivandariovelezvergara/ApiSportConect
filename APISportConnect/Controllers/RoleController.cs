using APISportConnect.Filter;
using BSportConect.Security;
using Entity.Service;
using Entity.Service.Security;
using Microsoft.AspNetCore.Mvc;

namespace APISportConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorizes("settings")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        #region GetAllRoles
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            BaseResponse response;
            List<RoleGetResponse> listRol;
            try
            {
                listRol = await _service.GetAllRolesAsync();
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

        #region GetRoleById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            BaseResponse response;
            try
            {
                var role = await _service.GetRoleByIdAsync(id);
                if (role == null)
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
                    return Ok(role);
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

        #region CreateRole
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleRequest role)
        {
            BaseResponse response;
            try
            {
                response = await _service.CreateRoleAsync(role);
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

        #region UpdateRole
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] RoleRequest role)
        {
            BaseResponse response;
            try
            {
                response = await _service.UpdateRoleAsync(id, role);
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

        #region DeleteRole
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            await _service.DeleteRoleAsync(id);
            return NoContent();
        }
        #endregion
    }
}
