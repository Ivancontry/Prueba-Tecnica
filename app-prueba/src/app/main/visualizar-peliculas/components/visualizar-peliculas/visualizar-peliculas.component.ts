import { Component, OnInit } from '@angular/core';
import { Pelicula as Movie } from '../../models/pelicula';
import { VisualizarPeliculasService } from '../../services/visualizar-peliculas.service';

@Component({
  selector: 'app-visualizar-peliculas',
  templateUrl: './visualizar-peliculas.component.html',
  styleUrls: ['./visualizar-peliculas.component.scss']
})
export class VisualizarPeliculasComponent implements OnInit {
  movies: Movie[] = [];
  length: number = 0;
  constructor(private _visualizarPeliculas: VisualizarPeliculasService) { 
    
  }

  ngOnInit(): void {
    let page = 1;
    this.getPeliculas(page);
  }
  getPeliculas(page) {
    this._visualizarPeliculas.get(page).subscribe(result => {
      if(!result){
        return;   
      }
      this.length = result.total_results;
      this.movies = result.results;
    });
  }

}
