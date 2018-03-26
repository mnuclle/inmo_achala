import { isDefined } from '@ng-bootstrap/ng-bootstrap/util/util';

export class DateUtils {

  private static REGEX_ISO: RegExp = /(\d{4})-(\d{2})-(\d{2})T(\d{2})\:(\d{2})\:(\d{2})/;

  public static convertToDate(fecha: string): Date {
    let match;
    if (DateUtils.isISODate(fecha)) {
      match = fecha.match(this.REGEX_ISO);
      let now = new Date(),
        tzo = -now.getTimezoneOffset(),
        dif = tzo >= 0 ? '+' : '-',
        pad = function (num) {
          let norm = Math.abs(Math.floor(num));
          return (norm < 10 ? '0' : '') + norm;
        };

      let date = match[0];

      if (date.search(/[-+]([0-9][0-9]):([0-9][0-9])/i) == -1) {
        date += dif + pad(tzo / 60) + ':' + pad(tzo % 60);
      }
      let milliseconds = Date.parse(date);
      if (isDefined(milliseconds)) {
        return new Date(milliseconds);
      }
    }
  }

  static isISODate(fecha: string): boolean {
    return (fecha && typeof fecha == 'string' && fecha.match(this.REGEX_ISO) != null);
  }

  static getManianaDate(): Date {
    let maniana = new Date();
    maniana.setHours(0, 0, 0, 0);
    maniana.setDate(maniana.getDate() + 1);
    return maniana;
  }

  static initDateToBeginingOfDay(date: Date): Date {
    if (isDefined(date) && date !== null && date instanceof Date) {
      date.setHours(0, 0, 0, 0);
      return date;
    }
    return null;
  }

  static obtenerNroMes(date: Date) {
    if (date instanceof Date) {
      return date.getMonth() + 1;
    }
    return null;
  }

  static obtenerNombreMes(numeroMes: number): string {
    if (numeroMes > 12) {
      return null;
    }
    return DateUtils.Meses.find((x) => {
      return x.nro === numeroMes;
    }).nombre;
  }

  static Meses = [
    {nro: 1, nombre: 'Enero'},
    {nro: 2, nombre: 'Febrero'},
    {nro: 3, nombre: 'Marzo'},
    {nro: 4, nombre: 'Abril'},
    {nro: 5, nombre: 'Mayo'},
    {nro: 6, nombre: 'Junio'},
    {nro: 7, nombre: 'Julio'},
    {nro: 8, nombre: 'Agosto'},
    {nro: 9, nombre: 'Septiembre'},
    {nro: 10, nombre: 'Octubre'},
    {nro: 11, nombre: 'Noviembre'},
    {nro: 12, nombre: 'Diciembre'},
  ];

}
