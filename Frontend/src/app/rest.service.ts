import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Weather } from './weather';
import { Observable } from 'rxjs';



const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
const WeatherApi= "https://localhost:44312/api/weather";
@Injectable({
  providedIn: 'root'
})
export class RestService {

  constructor(private http: HttpClient) {

  }
  GetWeather(City: string, Country: string): Observable<Weather>
  {
    const url = `${WeatherApi}/${Country}/${City}`;

    return this.http
          .get<Weather>(url, httpOptions)
          .pipe();
  }
}
