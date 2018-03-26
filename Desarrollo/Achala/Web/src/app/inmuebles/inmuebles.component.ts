import { Component, OnInit } from '@angular/core';
import { Inmueble } from '../shared/model/inmueble.model';

@Component({
  selector: 'app-inmuebles',
  templateUrl: './inmuebles.component.html',
  styleUrls: ['./inmuebles.component.css']
})
export class InmueblesComponent implements OnInit {

  inmueble: Inmueble = new Inmueble(1,
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
  1,
  Date.prototype,
  Date.prototype,
  Date.prototype,
  null,
  1,
  'S',
  1);

  constructor() { }

  ngOnInit() {
  }

}
