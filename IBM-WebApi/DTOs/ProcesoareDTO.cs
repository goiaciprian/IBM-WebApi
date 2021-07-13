using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.DTOs
{
    public class ProcesoareDTO
    {
        public Guid ID_Cpu { get; set; }

        public string Producator { get; set; }

        public string Model { get; set; }

        public bool Chipset { get; set; } = false;

        public int Pret { get; set; }

    }
}
