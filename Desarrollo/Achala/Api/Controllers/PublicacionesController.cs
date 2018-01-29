using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http;
using Api.Operaciones.Comandos;
using FluentNHibernate.Conventions.Inspections;
using Modelo;
using Servicios;

namespace Api.Controllers
{
    public class PublicacionesController : ApiController
    {
        private readonly PublicacionServicio _publicacionServicio;
        private readonly InmuebleServicio _inmuebleServicio;


        public PublicacionesController(PublicacionServicio publicacionServicio, InmuebleServicio inmuebleServicio)
        {
            this._publicacionServicio = publicacionServicio;
            this._inmuebleServicio = inmuebleServicio;
        }

        // GET: api/Publicaciones
        public IEnumerable<Publicacion> Get()
        {
            IList<Publicacion> listaPublicaciones = _publicacionServicio.ObtenerTodos();
            /* se comenta hasta saber como obtener todas por idInmueble.
            foreach (var inmueble in listaInmuebles)
            {
                inmueble.Imagenes = _imagenInmuebleServicio.Obtener
            }
            */
            return listaPublicaciones;
        }

        // GET: api/Publicaciones/5
        public IHttpActionResult Get(int id)
        {
            var publicacion = _publicacionServicio.ObtenerPorId(id);
            if (publicacion == null)
            {
                return NotFound();
            }

            return Ok(publicacion);
        }

        // POST: api/Publicacion
        public IHttpActionResult Post([FromBody]PublicacionCmd cmd)
        {
            var publicacion = new Publicacion();
            publicacion.Nombre = cmd.Nombre;
            publicacion.Descripcion = cmd.DescripcionPublicacion;
            publicacion.EstadoPublicacion = EstadoPublicacion.ACTIVO;
            publicacion.FechaModificacion = DateTime.Now;
            publicacion.FechaPublicacion = DateTime.Now;
            publicacion.Precio = cmd.Precio;
            publicacion.Prioridad = cmd.Prioridad;
            publicacion.TipoOperacion = cmd.IdTipoOperacion;
            publicacion.Inmueble = _inmuebleServicio.ObtenerPorId(cmd.IdInmueble);

            _publicacionServicio.Guardar(publicacion);
            return Ok();
        }

        // PUT: api/Inmuebles/5
        public IHttpActionResult Put(int id, [FromBody]PublicacionCmd cmd)
        {
            var publicacion = _publicacionServicio.ObtenerPorId(id);

            if (publicacion == null)
            {
                return NotFound();
            }
            publicacion.Nombre = cmd.Nombre;
            publicacion.Descripcion = cmd.DescripcionPublicacion;
            publicacion.EstadoPublicacion = cmd.IdEstadoPublicacion;
            publicacion.FechaModificacion = DateTime.Now;
            publicacion.FechaPublicacion = cmd.FechaPublicacion;
            publicacion.Precio = cmd.Precio;
            publicacion.Prioridad = cmd.Prioridad;
            publicacion.TipoOperacion = cmd.IdTipoOperacion;
            publicacion.Inmueble = _inmuebleServicio.ObtenerPorId(cmd.IdInmueble);

            _publicacionServicio.Guardar(publicacion);
            return Ok();

        }

        // DELETE: api/Inmuebles/5
        public IHttpActionResult Delete(int id)
        {
            var publicacion = _publicacionServicio.ObtenerPorId(id);
            if (publicacion == null)
            {
                return NotFound();
            }
            publicacion.FechaBaja = DateTime.Now;
            publicacion.FechaModificacion = DateTime.Now;
            publicacion.EstadoPublicacion = EstadoPublicacion.BAJA;
            _publicacionServicio.Guardar(publicacion);
            return Ok();
        }
    }
}