import { HttpClient, HttpParams } from "@angular/common/http"
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class VisualizarPeliculasService {
  api = 'https://api.themoviedb.org/3/movie/now_playing';
  constructor(private httpClient: HttpClient) { }
  get(page: number) {
    let params = new HttpParams()
      .append('api_key', '14a1e7de4368a6f1aa7846b910aa671c')
      .append('page', page.toString())
      .append('language', 'en-ES')
    return this.httpClient.get<any>(this.api, {
      params: params
    })
  }
}
