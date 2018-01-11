using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Modelo;

namespace Api.Operaciones.Comandos
{
    public class CrearInmuebleCmd
    {
        [Required(ErrorMessage = "El nombre del inmueble es un dato requerido")]
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public int Piso { get; set; }

        [Required(ErrorMessage = "El tipo de propiedad es un dato requerido")]
        public int IdTipoPropiedad { get; set; }
    }
}