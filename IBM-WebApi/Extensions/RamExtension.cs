using IBM_WebApi.DTOs;
using IBM_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Extensions
{
    public static class RamExtension
    {
        public static RamDTO toDTO(this Ram ram)
        {
            return new RamDTO()
            {
                ID_Ram = ram.ID_Ram,
                Model = ram.Model,
                Memorie = ram.Memorie,
                Pret = ram.Pret,
                Producator = ram.Producator
            };
        }

        public static Ram toEntity(this RamDTO ram)
        {
            return new Ram()
            {
                ID_Ram = ram.ID_Ram,
                Model = ram.Model,
                Memorie = ram.Memorie,
                Pret = ram.Pret,
                Producator = ram.Producator,
                Sters = false
            };
        }
    }
}
