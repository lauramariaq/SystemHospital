using System;
using System.Collections.Generic;
using System.Text;

namespace SytemHospital.Bi.Dto
{
    public class IncomeDto
    {

        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string TypeRoom { get; set; }
        public int RoomId { get; set; }
        public DateTimeOffset IncomeDate { get; set; }
       

    }
}
