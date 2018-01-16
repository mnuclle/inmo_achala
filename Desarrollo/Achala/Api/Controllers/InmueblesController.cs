using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Operaciones.Comandos;
using Castle.DynamicProxy;
using Modelo;

namespace Api.Controllers
{
    public class InmueblesController : ApiController
    {

        private readonly InmuebleServicio _inmuebleServicio;

        public InmueblesController(InmuebleServicio inmuebleServicio) {
            this._inmuebleServicio = inmuebleServicio;
        }

        // GET: api/Inmuebles
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Inmuebles/5
        public IHttpActionResult Get(int id)
        {
            var inmueble = _inmuebleServicio.ObtenerPorId(id);
            if (inmueble == null)
            {
                return NotFound();
            }

            return Ok(inmueble);
        }

        // POST: api/Inmuebles
        public IHttpActionResult Post([FromBody]CrearInmuebleCmd cmd)
        {
            var inmueble = new Inmueble();
            inmueble.Nombre = cmd.Nombre;
            inmueble.Descripcion = cmd.Descripcion;
            inmueble.Antiguedad = cmd.Antiguedad;
            inmueble.CantidadAmbientes = cmd.CantidadAmbientes;
            inmueble.CantidadBaños = cmd.CantidadBaños;
            inmueble.CantidadDormitorios = cmd.CantidadDormitorios;
            inmueble.EstadoInmueble = EstadoInmueble.ACTIVO;
            inmueble.TipoPropiedad = (TipoPropiedad)cmd.IdTipoPropiedad;
            inmueble.Imagenes = cmd.Imagenes;
            inmueble.Domicilio = new Domicilio()
            {
                Calle = cmd.Calle,
                Altura = cmd.Altura,
                Piso = cmd.Piso,
                Departamento = cmd.Departamento,
                Manzana = cmd.Manzana,
                Torre = cmd.Manzana,
                Latitud = cmd.Latitud,
                Longitud = cmd.Longitud,
                Lote = cmd.Lote,
                Barrio = new Barrio()
                {
                    Id = cmd.IdBarrio
                },
                Localidad = new Localidad()
                {
                    Id = cmd.IdLocalidad
                }
            };

            _inmuebleServicio.Guardar(inmueble);
            return Ok();
        }

        // PUT: api/Inmuebles/5
        public IHttpActionResult Put(int id, [FromBody]CrearInmuebleCmd cmd)
        {
            var inmueble = _inmuebleServicio.ObtenerPorId(id);
            if (inmueble == null)
            {
                return NotFound();
            }
            inmueble.Nombre = cmd.Nombre;
            inmueble.Descripcion = cmd.Descripcion;
            inmueble.Antiguedad = cmd.Antiguedad;
            inmueble.CantidadAmbientes = cmd.CantidadAmbientes;
            inmueble.CantidadBaños = cmd.CantidadBaños;
            inmueble.CantidadDormitorios = cmd.CantidadDormitorios;
            inmueble.EstadoInmueble = (EstadoInmueble)cmd.IdEstadoInmueble;
            inmueble.TipoPropiedad = (TipoPropiedad)cmd.IdTipoPropiedad;
            inmueble.Imagenes = cmd.Imagenes;
            inmueble.Domicilio = new Domicilio()
            {
                Calle = cmd.Calle,
                Altura = cmd.Altura,
                Piso = cmd.Piso,
                Departamento = cmd.Departamento,
                Manzana = cmd.Manzana,
                Torre = cmd.Manzana,
                Latitud = cmd.Latitud,
                Longitud = cmd.Longitud,
                Lote = cmd.Lote,
                Barrio = new Barrio()
                {
                    Id = cmd.IdBarrio
                },
                Localidad = new Localidad()
                {
                    Id = cmd.IdLocalidad
                }
            };

            _inmuebleServicio.Guardar(inmueble);
            return Ok();
            
        }

        // DELETE: api/Inmuebles/5
        public IHttpActionResult Delete(int id)
        {
            var inmueble = _inmuebleServicio.ObtenerPorId(id);
            if (inmueble == null)
            {
                return NotFound();
            }
            inmueble.FechaBaja = DateTime.Now;
            inmueble.EstadoInmueble = EstadoInmueble.BAJA;
            _inmuebleServicio.Eliminar(inmueble);
            return Ok();
        }
    }
}
