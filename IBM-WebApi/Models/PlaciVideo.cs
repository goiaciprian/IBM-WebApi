using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Models
{
    public class PlaciVideo
    {
        [Key]
        public int ID_Gpu { get; set; }
    
        [Required]
        public string Producator { get; set; }
    
        [Required]
        public string Model { get; set; }

        public string Tip { get; set; } = "dedicata";
        [Required]
        public int Pret { get; set; }

    }
}
