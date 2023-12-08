using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;
using ApplicationWeb.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IUserService _SuperAdminService;
        private readonly ILogger _logger;


        public UserController(IUserService superAdminService, ILogger<UserController> logger)
        {
            _SuperAdminService = superAdminService;
            _logger = logger;
        }

            
        [HttpGet("GetAllUser")]

        public ActionResult<List<UserGetDto>> GetAllUser()
        {
            string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;
            try
            {
                if (role == "SuperAdmin")
                {
                    var response = _SuperAdminService.GetAllUser();
                    if (response == null)
                    {
                        return BadRequest("User Not Found");
                    }
                    return response;
                }
                return NotFound("Incorrect Role");

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in GetAllUser: {ex}");
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost("AddUser")]
        public ActionResult<UserDto> AddUser([FromBody] UserViewModel user)
        {
            string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;

            try
            {
                if (role == "SuperAdmin")
                {
                    var response = _SuperAdminService.AddUser(user);


                    if (response == null)
                    {
                        return BadRequest("Incomplete Data or existing user ");
                    }
                    return Ok("Added User");
                }
                else
                {
                    return NotFound("Incorrect Role");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in AddUser: {ex}");
                return BadRequest($"{ex.Message}");
            }

        }

        [HttpDelete("DeleteUserByid/{id}")]

        public ActionResult<string> DeleteUserByid(int id)
        {

            string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;
            try
            {
                if (role == "SuperAdmin")
                {
                    var response = _SuperAdminService.DeleteUserByid(id);
                    if (response == "Delete User")
                    {
                        return response;

                    }
                    return NotFound("User Not Found");
                }
                else
                {
                    return NotFound("Incorrect Role");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in DeleteUserByid: {ex}");
                return BadRequest($"{ex.Message}");
            }

        }
    }
}
