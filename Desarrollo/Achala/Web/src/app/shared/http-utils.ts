export class HttpUtils {
  static insertarPrefijo(filtros: any, prefijo: string = 'consulta'): object {
    if (typeof filtros === 'object') {
      let parametros = {};
      Object.getOwnPropertyNames(filtros)
        .map((key: string) => {
          if (filtros[key]) {
            parametros[prefijo + '.' + key] = filtros[key]
          }
        });
      return parametros;
    }

  }
}
