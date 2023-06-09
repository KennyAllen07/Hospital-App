﻿using Hospital_App.Entities;

namespace Hospital_App.Models.DTOs
{
    public class CreateAppointmentDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        
    }
    public class UpdateAppointmentDto
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }

    }
    public class GetAppointmentDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public GetPatientDto GetPatient { get; set; }
        public GetDoctorDto GetDoctor { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }

    }

}
