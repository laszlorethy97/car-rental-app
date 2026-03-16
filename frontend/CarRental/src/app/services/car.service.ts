import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarsGetDto } from '../models/cars-get-dto';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  constructor(private readonly http: HttpClient){}
  
  load() :Observable<CarsGetDto[]>{
    return this.http.get<CarsGetDto[]>('http://localhost:5000/api/CarRental/cars');
  }
}
