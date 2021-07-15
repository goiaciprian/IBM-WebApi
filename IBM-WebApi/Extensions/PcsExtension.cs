using IBM_WebApi.DTOs;
using IBM_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Extensions
{
    public static class PcsExtension
    {
        public static PcsGetDTO toTDO(this PCs pc)
        {
            return new PcsGetDTO()
            {
                ID_Pc = pc.ID_Pc,
                Procesor = pc.procesor?.toDTO(),
                PlacaVideo = pc.placaVideo?.toDTO(),
                Ram = pc.ram?.toDTO(),
                Pret = pc.Pret
            };
        }

        public static PCs toEntity(this PcsEditDTO  pc, Procesoare cpu, PlaciVideo gpu, Ram ram)
        {
            return new PCs()
            {
                ID_Pc = pc.ID_Pc,
                ID_Gpu = pc.ID_Gpu,
                placaVideo = gpu,
                ID_Cpu = pc.ID_Cpu,
                procesor = cpu,
                ID_Ram = pc.ID_Ram,
                ram = ram,
                Pret =cpu.Pret + gpu.Pret + ram.Pret
            };
        }
    }
}
