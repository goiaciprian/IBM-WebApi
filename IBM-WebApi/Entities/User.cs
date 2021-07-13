using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Models
{
    public class User
    {
        [Key]
        public Guid Id_User { get; set; }
    
        [Required]
        [MaxLength(150)]
        public string Nume { get; set; }
    
        [Required]
        [MaxLength(150)]
        public string Prenume { get; set; }
    
        [Required]
        public string Email { get; set; }
    
        [Required]
        public string Parola { get; set; }

        public bool isAdmin { get; set; } = false;

        public bool? Sters { get; set; } = false;
    }
}
