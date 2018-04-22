using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Repositorios;

namespace Servicios
{
    public class InmuebleServicio
    {

        private readonly InmuebleRepositorio _inmuebleRepositorio;
        private readonly ImagenInmuebleRepositorio _imagenInmuebleRepositorio;

        public InmuebleServicio(InmuebleRepositorio inmuebleRepositorio, ImagenInmuebleRepositorio imagenInmuebleRepositorio)
        {
            this._inmuebleRepositorio = inmuebleRepositorio;
            this._imagenInmuebleRepositorio = imagenInmuebleRepositorio;
        }

        public void Guardar(Inmueble inmueble)
        {
            _inmuebleRepositorio.Guardar(inmueble);
            /*IList<Inmueble> listaTodos = ObtenerTodos();
            Inmueble idInmueble = null;
            foreach (var inmuebleReg in listaTodos)
            {
                if (
                    inmueble.Nombre == inmuebleReg.Nombre &&
                    inmueble.Descripcion == inmuebleReg.Descripcion &&
                    inmueble.CantidadAmbientes == inmuebleReg.CantidadAmbientes &&
                    inmueble.CantidadBaños == inmuebleReg.CantidadBaños &&
                    inmueble.CantidadDormitorios == inmuebleReg.CantidadDormitorios &&
                    inmueble.AEstrenar == inmuebleReg.AEstrenar &&
                    inmueble.Antiguedad == inmuebleReg.Antiguedad &&
                    inmueble.SuperficieCubierta == inmuebleReg.SuperficieCubierta &&
                    inmueble.SuperficieTerreno == inmuebleReg.SuperficieTerreno &&
                    inmueble.SuperficieTotal == inmuebleReg.SuperficieTotal &&
                    inmueble.TipoEmprendimiento == inmuebleReg.TipoEmprendimiento &&
                    inmueble.TipoPropiedad == inmuebleReg.TipoPropiedad &&
                    inmueble.UbicacionDepartamento == inmuebleReg.UbicacionDepartamento
                )
                {
                    idInmueble = inmuebleReg;
                    break;
                };
            }

            if (idInmueble != null)
            {
                if (inmueble.Imagenes != null)
                {
                    foreach (var imagen in inmueble.Imagenes)
                    {
                        imagen.Inmueble = idInmueble;
                        _imagenInmuebleRepositorio.Guardar(imagen);
                    }
                }
            }*/
        }

        public Inmueble ObtenerPorId(int id)
        {
            return _inmuebleRepositorio.ConsultarPorId(id);
        }

        public void Eliminar(Inmueble inmueble)
        {
            _inmuebleRepositorio.Eliminar(inmueble);
        }

        public IList<Inmueble> ObtenerTodos()
        {
            return _inmuebleRepositorio.ObtenerTodas();
        }
        
    }
}
