using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;

namespace Api.Operaciones.Comandos
{
    public class PublicacionCmd
    {
        public string Nombre { get; set; }
        public string DescripcionPublicacion { get; set; }
        public TipoOperacion IdTipoOperacion { get; set; }
        public double Precio { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public EstadoPublicacion IdEstadoPublicacion { get; set; }
        public int IdInmueble { get; set; }
        public int Prioridad { get; set; }
    }
}