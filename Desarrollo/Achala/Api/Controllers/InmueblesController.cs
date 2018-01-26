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
        private readonly BarrioServicio _barrioServicio;
        private readonly LocalidadServicio _localidadServicio;

        public InmueblesController(InmuebleServicio inmuebleServicio,BarrioServicio barrioServicio, LocalidadServicio localidadServicio) {
            this._inmuebleServicio = inmuebleServicio;
            this._barrioServicio = barrioServicio;
            this._localidadServicio = localidadServicio;
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
            var barrio = _barrioServicio.ObtenerPorId(cmd.IdBarrio);
            var localidad = _localidadServicio.ObtenerPorId(cmd.IdLocalidad);
            inmueble.Nombre = cmd.Nombre;
            inmueble.Descripcion = cmd.Descripcion;
            inmueble.Antiguedad = cmd.Antiguedad;
            inmueble.CantidadAmbientes = cmd.CantidadAmbientes;
            inmueble.CantidadBaños = cmd.CantidadBaños;
            inmueble.CantidadDormitorios = cmd.CantidadDormitorios;
            inmueble.EstadoInmueble = EstadoInmueble.ACTIVO;
            inmueble.TipoPropiedad = cmd.IdTipoPropiedad;
            
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
                Barrio = barrio,
                Localidad = localidad,
                TipoBarrio = cmd.IdTipoBarrio
            };
            inmueble.AEstrenar = cmd.AEstrenar;
            inmueble.UbicacionDepartamento = cmd.IdUbicacionDepartamento;
            inmueble.TipoEmprendimiento = cmd.IdTipoEmprendimiento;
            inmueble.FechaAlta = DateTime.Now;
            inmueble.FechaModificacion = DateTime.Now;

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
            inmueble.EstadoInmueble = cmd.IdEstadoInmueble;
            inmueble.TipoPropiedad = cmd.IdTipoPropiedad;
            
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
                    Id = (int)cmd.IdBarrio
                },
                Localidad = new Localidad()
                {
                    Id = (int)cmd.IdLocalidad
                },
                TipoBarrio = cmd.IdTipoBarrio
            };
            inmueble.AEstrenar = cmd.AEstrenar;
            inmueble.UbicacionDepartamento = cmd.IdUbicacionDepartamento;
            inmueble.TipoEmprendimiento = cmd.IdTipoEmprendimiento;
            inmueble.FechaModificacion = DateTime.Now;

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
            inmueble.FechaModificacion = DateTime.Now;
            inmueble.EstadoInmueble = EstadoInmueble.BAJA;
            _inmuebleServicio.Eliminar(inmueble);
            return Ok();
        }
    }
}
