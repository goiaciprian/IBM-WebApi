using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.DTOs
{
    public class UserDTO
    {
        public Guid Id_User { get; set; }

        public string Nume { get; set; }

        public string Prenume { get; set; }

        public string Email { get; set; }

        public string Parola { get; set; }

        public bool isAdmin { get; set; }

    }
}
