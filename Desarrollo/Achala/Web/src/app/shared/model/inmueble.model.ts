import { Imagen } from './imagen.model';
import { JsonProperty } from '../map-utils';
export class Inmueble {
  public id: number;
  public nombre: string;
  public descripcion: string;
  public superficieCubierta: number;
  public superficieTerreno: number;
  public superficieTotal: number;
  public cantidadBanios: number;
  public cantidadAmbientes: number;
  public cantidadDormitorios: number;
  public antiguedad: number;
  public domicilioId: number;
  public tipoPropiedadId: number;
  public estadoInmuebleId: number;
  public fechaBaja: Date;
  public fechaAlta: Date;
  public fechaModificacion: Date;
  @JsonProperty({clazz: Imagen})
  public imagenes: Imagen[];
  public ubicacionDepartamentoId: number;
  public aEstrenar: boolean;
  public tipoEmprendimientoId: number;

  constructor(id?: number,
              nombre?: string,
              descripcion?: string,
              superficieCubierta?: number,
              superficieTerreno?: number,
              superficieTotal?: number,
              cantidadBanios?: number,
              cantidadAmbientes?: number,
              cantidadDormitorios?: number,
              antiguedad?: number,
              domicilioId?: number,
              tipoPropiedadId?: number,
              estadoInmuebleId?: number,
              fechaBaja?: Date,
              fechaAlta?: Date,
              fechaModificacion?: Date,
              imagenes?: Imagen[],
              ubicacionDepartamentoId?: number,
              aEstrenar?: boolean,
              tipoEmprendimientoId?: number) {
    this.id = id ? id : null;
    this.nombre = nombre;
    this.descripcion = descripcion ?  descripcion : null;
    this.superficieCubierta = superficieCubierta;
    this.superficieTerreno = superficieTerreno;
    this.superficieTotal = superficieTotal;
    this.cantidadBanios = cantidadBanios;
    this.cantidadAmbientes = cantidadAmbientes;
    this.cantidadDormitorios = cantidadDormitorios;
    this.antiguedad = antiguedad;
    this.domicilioId = domicilioId;
    this.tipoPropiedadId = tipoPropiedadId;
    this.estadoInmuebleId = estadoInmuebleId;
    this.fechaBaja = fechaBaja;
    this.fechaAlta = fechaAlta;
    this.fechaModificacion = fechaModificacion;
    this.imagenes = imagenes;
    this.ubicacionDepartamentoId = ubicacionDepartamentoId;
    this.aEstrenar = aEstrenar;
    this.tipoEmprendimientoId = tipoEmprendimientoId ? tipoEmprendimientoId : null;
  }
}
