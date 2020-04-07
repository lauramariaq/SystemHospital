using System;
using System.Collections.Generic;
using System.Text;

namespace SytemHospital.Model.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Type { get; set; }

        public int Price { get; set; }
    }
}
