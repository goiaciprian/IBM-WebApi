using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.DTOs
{
    public class RamDTO
    {
        public Guid ID_Ram { get; set; }

        public string Producator { get; set; }

        public string Model { get; set; }

        public int Memorie { get; set; }

        public int Pret { get; set; }
    }
}
