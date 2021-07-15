using IBM_WebApi.DTOs;
using IBM_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Extensions
{
    public static class ProcesoareExtension
    {
        public static ProcesoareDTO toDTO(this Procesoare cpu)
        {
            return new ProcesoareDTO()
            {
                Chipset = cpu.Chipset,
                ID_Cpu = cpu.ID_Cpu,
                Model = cpu.Model,
                Pret = cpu.Pret,
                Producator = cpu.Producator
            };
        }

        public static Procesoare toEntity(this ProcesoareDTO cpu)
        {
            return new Procesoare()
            {
                Chipset = cpu.Chipset,
                ID_Cpu = cpu.ID_Cpu,
                Model = cpu.Model,
                Pret = cpu.Pret,
                Producator = cpu.Producator,
                Sters = false
            };
        }
    }
}
