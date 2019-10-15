using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
    public interface IMesaService
    {
        List<Mesa> ObtenerMesas(int resid);
        Mesa Obtener(int id);
        int Agregar(Mesa mesa);
        void Editar(Mesa mesa);

        void Eliminar(int id);
        void Eliminar(int[] ids);
    }
}
