using System;
using System.Collections.Generic;
using System.Text;
using SytemHospital.Model.GenericModel;

namespace SytemHospital.Model.Entities
{
    public class Patient : BaseModel
    {
        public int Id { get; set; }

        public string Cedula { get; set; }

        public string Name { get; set; }

        public bool Insurance { get; set; }
    }
}
