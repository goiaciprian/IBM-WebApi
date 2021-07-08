using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Models
{
    public class Procesoare
    {
        [Key]
        public int ID_Cpu { get; set; }
        [Required]
        public string Producator { get; set; }

        [Required]
        public string Model { get; set; }

        public bool Chipset { get; set; } = false;
    
        [Required]
        public int Pret { get; set; }

    }
}
