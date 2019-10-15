using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
    public interface IOrdenProductoService
    {
        void Agregar(OrdenTieneProducto prod);
        void Editar(OrdenTieneProducto prod);
        void Eliminar(int ordenId, int productoId);

        OrdenTieneProducto Obtener(int ordenId, int productoId);

        List<OrdenTieneProducto> ObtenerTodas(int ordenId);
    }
}
