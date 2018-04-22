import { Injectable } from '@angular/core';
import { Inmueble } from '../shared/model/inmueble.model';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import {DateUtils} from '../shared/date-utils';


@Injectable()
export class InmuebleService {
  inm: Inmueble;
  constructor() { }

  getInmueble(): Observable<Inmueble> {

    this.inm = new Inmueble(1,
    'NOMBRE',
    'DESCRIPCIÓN',
    1,
    2,
    3,
    4,
    5,
    6,
    7,
    8,
    1,
    47,
    Date.now(),//revisar estooo
    null,
    null,
    null,
    1,
    true,
    1);
    return of (this.inm) ;
  }
}

