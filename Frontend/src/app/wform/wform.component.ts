import { Component, OnInit } from '@angular/core';
import { RestService } from '../rest.service';
import { Weather } from '../weather';
import {map} from "rxjs/internal/operators";
import { Query } from '../query';

@Component({
  selector: 'app-wform',
  templateUrl: './wform.component.html',
  styleUrls: ['./wform.component.css']
})
export class WFormComponent implements OnInit {

  constructor(private Rest: RestService) { }
  Query = new Query();
  Weather: Weather;
  submitted = false;
  IsResponse = false;
  ngOnInit() {
  }
  onSubmit() { 
    this.submitted = true;
    this.GetWeather();
  }
  GetWeather()
  {
    this.Rest.GetWeather(this.Query.country, this.Query.city)
        .pipe(map(
            data=>{
              console.log(data);
              this.IsResponse= true;
              return data;
            }))
        .subscribe(p=>this.Weather=p);
  }
  get diagnostic() { return JSON.stringify(this.Query); }

}
