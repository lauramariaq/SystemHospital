using System;
using System.Collections.Generic;
using System.Text;

namespace SytemHospital.Model.Entities
{
    public class Alta
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string TypeRoom { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public int TotalPrice { get; set; }
        public int IncomeId { get; set; }

        public virtual Income Income { get; set; }


    }
}
