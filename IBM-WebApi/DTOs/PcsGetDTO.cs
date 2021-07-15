using IBM_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.DTOs
{
    public class PcsGetDTO
    {
        public Guid ID_Pc { get; set; }

        public ProcesoareDTO Procesor { get; set; }

        public PlaciVideoDTO PlacaVideo { get; set; }

        public RamDTO Ram { get; set; }

        public int Pret { get; set; }
    }
}
