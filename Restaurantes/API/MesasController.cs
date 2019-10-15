using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesasController : ControllerBase
    {
        private readonly IMesaService _mesaService;
        private readonly IMapper _mapper;
        public MesasController(IMesaService mesaService, IMapper mapper)
        {
            _mesaService = mesaService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<List<MesaDTO>> Get(int resid)
        {
            var mesas = _mesaService.ObtenerMesas(resid);
            var model = new List<MesaDTO>();

            _mapper.Map(mesas, model);
            return model;
        }

        [HttpPost]
        public void Post([FromBody] MesaViewModel model)
        {
            var mesa = new Mesa();
            _mapper.Map(model, mesa);
            _mesaService.Agregar(mesa);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, MesaViewModel model)
        {
            var mesa = _mesaService.Obtener(id);

            if (mesa == null)
                return BadRequest();

            mesa.Identificador = model.Identificador;
            mesa.Capacidad = model.Capacidad;

            _mesaService.Editar(mesa);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var mesa = _mesaService.Obtener(id);

            if (mesa == null)
                return BadRequest();

            _mesaService.Eliminar(id);

            return Ok();

        }

        [HttpDelete]
        public ActionResult Delete([FromBody] int[] ids)
        {

            _mesaService.Eliminar(ids);

            return Ok();

        }
    }
}