﻿using Microsoft.EntityFrameworkCore;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurantes.Infrastructure.Services
{
    public class RestauranteService : IRestauranteService
    {
        public AppDbContext _context;
        public RestauranteService(AppDbContext context)
        {
            _context = context;
        }

        public Restaurante Obtener(int id)
        {
            return _context.Restaurantes.FirstOrDefault(c => c.Id == id);
        }

        public List<Restaurante> ObtenerRestaurantes()
        {
            return _context.Restaurantes.Include(c => c.Mesas).ToList();
        }

        public int Agregar(Restaurante restaurante)
        {
            _context.Add(restaurante);
            _context.SaveChanges();

            return restaurante.Id;
        }

        public void Editar(Restaurante restaurante)
        {
            _context.Update(restaurante);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var restaurante = _context.Restaurantes.FirstOrDefault(c => c.Id == id);

            _context.Remove(restaurante);
            _context.SaveChanges();
        }


        public void Eliminar(int[] ids)
        {
            
            foreach (var i in ids)
            {
                var restaurante = _context.Restaurantes.FirstOrDefault(c => c.Id == i);

                _context.Remove(restaurante);

            }
            _context.SaveChanges();

        }
    }
}
