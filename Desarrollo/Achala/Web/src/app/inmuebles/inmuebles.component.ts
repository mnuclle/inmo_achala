import { Component, OnInit } from '@angular/core';
import { Inmueble } from '../shared/model/inmueble.model';
import { InmuebleService } from './inmueble.service';

@Component({
  selector: 'app-inmuebles',
  templateUrl: './inmuebles.component.html',
  styleUrls: ['./inmuebles.component.css']
})

export class InmueblesComponent implements OnInit {
  constructor(private inmuebleService: InmuebleService) { }

  inmueble: Inmueble;

  ngOnInit() {
    this.getInmueble();
  }

  getInmueble(): void {
    this.inmuebleService.getInmueble()
      .subscribe(inmueble => this.inmueble = inmueble);
  }

}
