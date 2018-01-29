using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Repositorios;

namespace Servicios
{
    public class PublicacionServicio
    {
        private readonly PublicacionRepositorio _publicacionRepositorio;
        

        public PublicacionServicio(PublicacionRepositorio publicacionRepositorio)
        {
            this._publicacionRepositorio = publicacionRepositorio;
        }

        public void Guardar(Publicacion publicacion)
        {
            _publicacionRepositorio.Guardar(publicacion);
        }

        public Publicacion ObtenerPorId(int id)
        {
            return _publicacionRepositorio.ConsultarPorId(id);
        }

        public void Eliminar(Publicacion publicacion)
        {
            _publicacionRepositorio.Eliminar(publicacion);
        }

        public IList<Publicacion> ObtenerTodos()
        {
            return _publicacionRepositorio.ObtenerTodas();
        }

    }
}
