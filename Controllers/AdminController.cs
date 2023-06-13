using Hospital_App.Interface.IService;
using Hospital_App.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_App.Controllers
{
    [Route("Hospital/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        // GET: api/<AdminController>
        [HttpPost("AddAdmin")]
        public async Task<IActionResult> AddAdmin([FromForm] CreateAdminDto createAdminDto)
        {
            var admin = await _adminService.AddAdmin(createAdminDto);
            if(admin.Success == true)
            {
                return Ok(admin);
            }
            return BadRequest(admin);
        }
        // PUT : UpdateAdmin
        [HttpPut("UpdateAdmin")]
        public async Task<IActionResult> UpdateAdmin(int id, [FromForm] UpdateAdminDto updateAdminDto)
        {
            var admin = await _adminService.UpdateAdmin(id, updateAdminDto);
            if(admin.Success == true)
            {
                return Ok(admin);
            }
            return BadRequest(admin);
        }

        // GET : GetAdminById
        [HttpGet("GetAdminById")]
       public async Task<IActionResult> GetAdminById(int id)
        {
            var admin = await _adminService.GetAdminById(id);
            if(admin.Success == true)
            {
                return Ok(admin);
            }
            return BadRequest(admin);
        }

        // GET : DisplayAdmins
        [HttpGet("DisplayAdmins")]
       public async Task<IActionResult> DisplayAdmins()
        {
            var admins = await _adminService.GetAllAdmins();
            if(admins.Success == true)
            {
                return Ok(admins);
            }
            return BadRequest(admins);
        }

        // GET : DeleteAdmin
        [HttpDelete("DeleteAdmin")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var admin = await _adminService.DeleteAdmin(id);
            if(admin.Success == true)
            {
                return Ok(admin);
            }
            return BadRequest(admin);
        }

        // GET : GetAdmin
        [HttpGet("GetAdmin")]
        public async Task<IActionResult> GetAdmin(int id)
        {
            var admin = await _adminService.GetAdminById(id);
            if(admin.Success == true)
            {
                return Ok(admin);
            }
            return BadRequest(admin);
        }
    }
}
