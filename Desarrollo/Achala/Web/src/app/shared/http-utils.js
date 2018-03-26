"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var HttpUtils = (function () {
    function HttpUtils() {
    }
    HttpUtils.insertarPrefijo = function (filtros, prefijo) {
        if (prefijo === void 0) { prefijo = 'consulta'; }
        if (typeof filtros === 'object') {
            var parametros_1 = {};
            Object.getOwnPropertyNames(filtros)
                .map(function (key) {
                if (filtros[key]) {
                    parametros_1[prefijo + '.' + key] = filtros[key];
                }
            });
            return parametros_1;
        }
    };
    return HttpUtils;
}());
exports.HttpUtils = HttpUtils;
