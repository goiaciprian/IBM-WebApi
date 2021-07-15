using IBM_WebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.DTOs
{
    public class PcsEditDTO
    {
        public Guid ID_Pc { get; set; }

        public Guid ID_Cpu { get; set; }

        public Guid ID_Gpu { get; set; }

        public Guid ID_Ram { get; set; }

    }
}
