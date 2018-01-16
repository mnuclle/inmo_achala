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
        public string Descripcion { get; set; }
        public int SuperficieCubierta { get; set; }
        public int SuperficieTerreno { get; set; }
        public int SuperficieTotal { get; set; }
        public int CantidadBaños { get; set; }
        public int CantidadAmbientes { get; set; }
        public int CantidadDormitorios { get; set; }
        public int Antiguedad { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public int Piso { get; set; }
        public string Departamento { get; set; }
        public string Torre { get; set; }
        public string Manzana { get; set; }
        public string Lote { get; set; }
        public int IdBarrio { get; set; }
        public int IdLocalidad { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int IdTipoPropiedad { get; set; }
        public int IdEstadoInmueble { get; set; }
        public List<ImagenInmueble> Imagenes { get; set; }
    }
}