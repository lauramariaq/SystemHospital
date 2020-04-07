using System;
using System.Collections.Generic;
using System.Text;
using SytemHospital.Model.GenericModel;

namespace SytemHospital.Model.Entities
{
   public class Doctor : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Exequator { get; set; }
        public string Specialty { get; set; }

    }
}
