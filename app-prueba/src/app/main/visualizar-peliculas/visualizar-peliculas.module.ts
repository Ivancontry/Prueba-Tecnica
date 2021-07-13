import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VisualizarPeliculasComponent } from './components/visualizar-peliculas/visualizar-peliculas.component';
import { CommonsModule } from 'src/app/commons/commons.module';



@NgModule({
  declarations: [VisualizarPeliculasComponent],
  imports: [
    CommonModule,
    CommonsModule

  ],
  exports: [VisualizarPeliculasComponent]
})
export class VisualizarPeliculasModule { }
