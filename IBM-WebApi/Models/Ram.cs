using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Models
{
    public class Ram
    {
        [Key]
        public Guid ID_Ram { get; set; }

        [Required]
        public string Producator { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Memorie { get; set; }

        [Required]
        public int Pret { get; set; }


        public bool? Sters { get; set; } = false;
    }
}
