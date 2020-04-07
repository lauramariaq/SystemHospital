using System;
using System.Collections.Generic;
using System.Text;

namespace SytemHospital.Model.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        public string Cedula { get; set; }

        public string Name { get; set; }

        public bool Insurance { get; set; }
    }
}
