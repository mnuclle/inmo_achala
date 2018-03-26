import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { InmueblesComponent } from './inmuebles/inmuebles.component';


@NgModule({
  declarations: [
    AppComponent,
    InmueblesComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
