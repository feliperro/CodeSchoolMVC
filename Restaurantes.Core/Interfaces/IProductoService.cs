using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
    public interface IProductoService
    {
        List<Producto> ObtenerProductos(int resid);
        Producto Obtener(int id);
        int Agregar(Producto prod);
        void Editar(Producto prod);

        void Eliminar(int id);
        void Eliminar(int[] ids);
    }
}
