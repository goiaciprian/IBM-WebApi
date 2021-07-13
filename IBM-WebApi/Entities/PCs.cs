using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Models
{
    public class PCs
    {
        [Key]
        public Guid ID_Pc { get; set; }

        [Required]
        public Guid ID_Cpu { get; set; }

        [ForeignKey("ID_Cpu")]
        public virtual Procesoare procesor { get; set; }

        [Required]
        public Guid ID_Gpu { get; set; }

        [ForeignKey("ID_Gpu")]
        public virtual PlaciVideo placaVideo { get; set; }

        [Required]
        public Guid ID_Ram { get; set; }

        [ForeignKey("ID_Ram")]
        public virtual Ram ram { get; set; }

        [Required]
        public int Pret { get; set; }

        public bool? Sters { get; set; } = false;

    }
}
