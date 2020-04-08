using System;
using System.Collections.Generic;
using System.Text;

namespace SytemHospital.Bi.Dto
{
    public class DateDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTimeOffset OpendDate { get; set; }

    }
}
