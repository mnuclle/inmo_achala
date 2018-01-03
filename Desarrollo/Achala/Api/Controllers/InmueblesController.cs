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
            inmueble.TipoPropiedad = (TipoPropiedad)cmd.IdTipoPropiedad;
            inmueble.Domicilio = new Domicilio()
            {
                Calle = cmd.Calle,
                Altura = cmd.Altura,
                Piso = cmd.Piso
            };

            _inmuebleServicio.Guardar(inmueble);
            return Ok();
        }

        // PUT: api/Inmuebles/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Inmuebles/5
        public void Delete(int id)
        {
        }
    }
}
