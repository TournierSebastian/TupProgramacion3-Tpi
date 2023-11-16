
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.ViewModel;
using ApplicationWeb.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Service.IService;
using System.Data;

namespace AplicacionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SuperAdminController : ControllerBase
    {
        private readonly ISuperAdminService _SuperAdminService;
        private readonly ILogger _logger;
        private readonly IAuthService _AuthService;

        public SuperAdminController(ISuperAdminService superAdminService, ILogger<SuperAdminController> logger, IAuthService authService)
        {
            _SuperAdminService = superAdminService;
            _logger = logger;
            _AuthService = authService;
        }
       
        [HttpGet("GetAllUser")] 

        public ActionResult<List<DtoUser>> GetAllUser()
        {
            string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;
            try
            {
                if (role == "SuperAdmin")
                {
                    var response = _SuperAdminService.GetAllUser();
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
        public ActionResult <UserViewModel> AddUser([FromBody] UserViewModel user)
        {
            string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;
         
                try {
                if (role == "SuperAdmin")
                {
                    var response = _SuperAdminService.AddUser(user);
                    
                    
                    if (response == null)
                    {
                        return Ok("Incomplete Data or existing user ");
                    }return Ok("Added User");
                }
                else
                {
                    return NotFound("Incorrect Role");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"An error occurred in AddUser: {ex}");
                return BadRequest($"{ex.Message}");
            }

        }

        [HttpDelete("DeleteUserByid/{id}")]

        public ActionResult<string> DeleteUserByid(int id){

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
