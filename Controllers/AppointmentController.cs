using Hospital_App.Interface.IService;
using Hospital_App.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

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

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
