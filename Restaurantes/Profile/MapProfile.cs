﻿using Restaurantes.Core.Entities;
using Restaurantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Profile
{
    public class MapProfile : AutoMapper.Profile
    {
       public MapProfile()
        {
            CreateMap<Restaurante, RestauranteViewModel>().ReverseMap();
            CreateMap<Restaurante, RestauranteDTO>().ForMember(c => c.Mesas, opt => opt.MapFrom(src => src.Mesas.Count())).ReverseMap();
            //CreateMap<Restaurante, RestauranteDTO>().ForMember(c => c.Productos, opt => opt.MapFrom(src => src.Productos.Count())).ReverseMap();
            CreateMap<Mesa, MesaViewModel>().ReverseMap();
            CreateMap<Mesa, MesaDTO>().ReverseMap();
            CreateMap<Producto, ProductoViewModel>().ReverseMap();
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<Orden, OrdenViewModel>().ReverseMap();
        }
    }
}
    