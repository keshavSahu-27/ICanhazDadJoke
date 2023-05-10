import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounce, interval, switchMap } from 'rxjs';
import { DadJoke } from 'src/contract/contract';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public jokes: DadJoke[] = [];
  public term = new FormControl();
  constructor(public appService: AppService){}

  ngOnInit(){
    this.fetchJokeByTerm();
  }

  async fetchRandomJoke(){
    let jokes = await this.appService.fetchRandomJoke().toPromise();
    this.jokes = new Array(jokes as DadJoke);
  }

fetchJokeByTerm(){
    this.term.valueChanges.pipe(
      debounce(() => interval(500)),
      switchMap(value => this.appService.getJokesByTerm(value))
    ).subscribe(res => {
      this.jokes = [...res.results.short, ...res.results.medium, ...res.results.long];
    })
  }
}
