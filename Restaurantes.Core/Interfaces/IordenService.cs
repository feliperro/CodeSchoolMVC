using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
    public interface IordenService
    {
        List<Orden> ObtenerOrdenes(int id);
        Orden Obtener(int id);
        int Agregar(Orden orden);
        void Editar(Orden orden);
        int Eliminar(int id);
    }
}
