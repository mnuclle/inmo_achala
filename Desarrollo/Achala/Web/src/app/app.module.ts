import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';


import { AppComponent } from './app.component';
import { InmueblesComponent } from './inmuebles/inmuebles.component';
import {InmuebleService} from './inmuebles/inmueble.service';


@NgModule({
  declarations: [
    AppComponent,
    InmueblesComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    FormsModule
  ],
  providers: [
    InmuebleService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
