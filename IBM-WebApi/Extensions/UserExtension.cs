using IBM_WebApi.DTOs;
using IBM_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Extensions
{
    public static class UserExtension
    {
        public static UserDTO toDTO(this User user)
        {
            return new UserDTO()
            {
                Id_User = user.Id_User,
                Nume = user.Nume,
                Prenume = user.Prenume,
                Email = user.Email,
                Parola = user.Parola,
                isAdmin = user.isAdmin
            };
        }

        public static User toEntity(this UserDTO user)
        {
            return new User()
            {
                Id_User = user.Id_User,
                Nume = user.Nume,
                Prenume = user.Prenume,
                Email = user.Email,
                Parola = user.Parola,
                isAdmin = user.isAdmin,
                Sters = false
            };
        }
    }
}
