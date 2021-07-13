import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { VisualizarPeliculasModule } from './main/visualizar-peliculas/visualizar-peliculas.module';
import { VisualizarPeliculasService } from './main/visualizar-peliculas/services/visualizar-peliculas.service';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    VisualizarPeliculasModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [VisualizarPeliculasService],
  bootstrap: [AppComponent]
})
export class AppModule { }
