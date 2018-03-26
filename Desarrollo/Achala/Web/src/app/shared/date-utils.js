"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var util_1 = require("@ng-bootstrap/ng-bootstrap/util/util");
var DateUtils = (function () {
    function DateUtils() {
    }
    DateUtils.convertToDate = function (fecha) {
        var match;
        if (DateUtils.isISODate(fecha)) {
            match = fecha.match(this.REGEX_ISO);
            var now = new Date(), tzo = -now.getTimezoneOffset(), dif = tzo >= 0 ? '+' : '-', pad = function (num) {
                var norm = Math.abs(Math.floor(num));
                return (norm < 10 ? '0' : '') + norm;
            };
            var date = match[0];
            if (date.search(/[-+]([0-9][0-9]):([0-9][0-9])/i) == -1) {
                date += dif + pad(tzo / 60) + ':' + pad(tzo % 60);
            }
            var milliseconds = Date.parse(date);
            if (util_1.isDefined(milliseconds)) {
                return new Date(milliseconds);
            }
        }
    };
    DateUtils.isISODate = function (fecha) {
        return (fecha && typeof fecha == 'string' && fecha.match(this.REGEX_ISO) != null);
    };
    DateUtils.getManianaDate = function () {
        var maniana = new Date();
        maniana.setHours(0, 0, 0, 0);
        maniana.setDate(maniana.getDate() + 1);
        return maniana;
    };
    DateUtils.initDateToBeginingOfDay = function (date) {
        if (date instanceof Date) {
            date.setHours(0, 0, 0, 0);
            return date;
        }
        return null;
    };
    return DateUtils;
}());
DateUtils.REGEX_ISO = /(\d{4})-(\d{2})-(\d{2})T(\d{2})\:(\d{2})\:(\d{2})/;
exports.DateUtils = DateUtils;
