using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Models
{
    public class PCs
    {
        [Key]
        public int ID_Pc { get; set; }

        [Required]
        public int ID_Cpu { get; set; }

        [Required]
        public int ID_Gpu { get; set; }

        [Required]
        public int ID_Ram { get; set; }

        [Required]
        public int Pret { get; set; }

    }
}
