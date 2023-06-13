using Hospital_App.Interface.IService;
using Hospital_App.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_App.Controllers
{
    [Route("Hospital/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("CreateAppointment")]
        public async Task<IActionResult> CreateAppointment([FromForm] CreateAppointmentDto createAppointmentDto)
        {
            var appointment = await _appointmentService.AddAppointment(createAppointmentDto);
            if(appointment.Success == true)
            {
                return Ok(appointment);
            }
            return BadRequest(appointment);
        }

        // PUT UpdateAppointment
        [HttpPut("UpdateAppointment")]
       public async Task<IActionResult> UpdateAppointment(int id, [FromForm] UpdateAppointmentDto updateAppointmentDto)
        {
            var appointment = await _appointmentService.UpdateAppointment(id, updateAppointmentDto);
            if(appointment.Success == true)
            {
                return Ok(appointment);
            }
            return BadRequest(appointment);
        }

       
        [HttpGet("GetAppointment")]
       public async Task<IActionResult> GetAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointment(id);
            if(appointment.Success == true)
            {
                return Ok(appointment);
            }
            return BadRequest(appointment);
        }

        // PUT api/<AppointmentController>/5
        [HttpGet("GetAllAppointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointments();
            if(appointments.Success == true)
            {
                return Ok(appointments);
            }
            return BadRequest(appointments);
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("DeleteAppointment")]
       public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _appointmentService.DeleteAppointment(id);
            if(appointment.Success == true)
            {
                return Ok(appointment);
            }
            return BadRequest(appointment);
        }
    }
}
