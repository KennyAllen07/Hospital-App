using Hospital_App.Interface.IService;
using Hospital_App.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_App.Controllers
{
    [Route("Hospital/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        // POST : AddDoctor
        [HttpPost("AddDoctor")]
        public async Task<IActionResult> AddDoctor([FromForm]CreateDoctorDto createDoctorDto)
        {
            var doctor = await _doctorService.AddDoctor(createDoctorDto);
            if(doctor.Success == true)
            {
                return Ok(doctor);
            }
            return BadRequest(doctor);
        }

        // PUT : UpdateDoctor
        [HttpPut("UpdateDoctor")]
       public async Task<IActionResult> UpdateDoctor(int id, [FromForm]UpdateDoctorDto updateDoctorDto)
        {
            var doctor = await _doctorService.UpdateDoctor(id, updateDoctorDto);
            if(doctor.Success == true)
            {
                return Ok(doctor);
            }
            return BadRequest(doctor);
        }

        // GET : DeleteDoctor
        [HttpDelete("DeleteDoctor")]
      public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _doctorService.DeleteDoctor(id);
            if(doctor.Success == true)
            {
                return Ok(doctor);
            }
            return BadRequest(doctor);
        }

        // GET : GetDoctor
        [HttpGet("GetDoctor")]
       public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctor(id);
            if(doctor.Success == true)
            {
                return Ok(doctor);
            }
            return BadRequest(doctor);
        }

        // GET : DisplayDoctors
        [HttpGet("DisplayDoctors")]
        public async Task<IActionResult> DisplayDoctors()
        {
            var doctors = await _doctorService.GetAllDoctors();
            if(doctors.Success == true)
            {
                return Ok(doctors);
            }
            return BadRequest(doctors);
        }
        //GET : DisplayDoctorsByName
        [HttpGet("DisplayDoctorsByName")]
        public async Task<IActionResult> DisplayDoctorsByName(string name)
        {
            var doctors = await _doctorService.GetAllDoctorsByName(name);
            if(doctors.Success == true)
            {
                return Ok(doctors);
            }
            return BadRequest(doctors);
        }
    }
}
