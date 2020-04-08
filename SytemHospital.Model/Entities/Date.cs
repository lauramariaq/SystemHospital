using System;
using System.Collections.Generic;
using System.Text;
using SytemHospital.Model.GenericModel;

namespace SytemHospital.Model.Entities
{
    public class Date :  BaseModel
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string  DoctorName { get; set; }
        public DateTimeOffset OpendDate { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }

}
