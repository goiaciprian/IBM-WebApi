using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.DTOs
{
    public class PlaciVideoDTO
    {
        public Guid ID_Gpu { get; set; }

        public string Producator { get; set; }

        public string Model { get; set; }

        public string Tip { get; set; } = "dedicata";
        public int Pret { get; set; }
    }
}
