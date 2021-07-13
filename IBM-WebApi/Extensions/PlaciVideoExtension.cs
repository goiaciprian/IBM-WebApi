using IBM_WebApi.DTOs;
using IBM_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Extensions
{
    public static class PlaciVideoExtension
    {
        public static PlaciVideoDTO toDTO(this PlaciVideo gpu)
        {
            return new PlaciVideoDTO()
            {
                ID_Gpu = gpu.ID_Gpu,
                Model = gpu.Model,
                Pret = gpu.Pret,
                Producator = gpu.Producator,
                Tip = gpu.Tip
            };
        }

        public static PlaciVideo toEntity(this PlaciVideoDTO gpu)
        {
            return new PlaciVideo()
            {
                ID_Gpu = gpu.ID_Gpu,
                Model = gpu.Model,
                Pret = gpu.Pret,
                Producator = gpu.Producator,
                Tip = gpu.Tip,
                Sters = false
            };
        }
    }
}
