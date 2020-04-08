using System;
using System.Collections.Generic;
using System.Text;

namespace SytemHospital.Model.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string TypeRoom { get; set; }
        public int RoomId { get; set; }
        public DateTimeOffset IncomeDate { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Room Room { get; set; }


    }
}
