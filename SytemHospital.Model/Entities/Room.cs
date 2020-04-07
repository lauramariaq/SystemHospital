using System;
using System.Collections.Generic;
using System.Text;
using SytemHospital.Model.GenericModel;

namespace SytemHospital.Model.Entities
{
    public class Room : BaseModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Type { get; set; }

        public int Price { get; set; }
    }
}
