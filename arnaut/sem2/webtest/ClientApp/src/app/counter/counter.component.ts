import {Component, Inject} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css']
})

export class CounterComponent {
  public currentCount = 1;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  public incrementCounter() {
    console.log(this.baseUrl + 'weatherforecast/' + this.currentCount);
    this.http.get<number>(this.baseUrl + 'weatherforecast/' + this.currentCount).subscribe(result => {
      this.currentCount = result;
    }, error => console.error(error));
  }
}
