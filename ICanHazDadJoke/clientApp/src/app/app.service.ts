import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ModSearchedJoke, RandomJoke } from 'src/contract/contract';

@Injectable({
    providedIn:"root"
})
export class AppService {
  constructor(private http: HttpClient) { }

  fetchRandomJoke(){
    return this.http.get<RandomJoke>('https://localhost:7213/api/fetchRandomJoke');
  }

  getJokesByTerm(term: string){
    let params = new HttpParams().append('page', 1)
    .append('limit', 30)
    .append('term', term);
    return this.http.get<ModSearchedJoke>('https://localhost:7213/api/getJokesByTerm', {params: params});
  }
}