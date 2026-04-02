import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarsGetDto } from '../models/cars-get-dto';
import { CarRentPostDto } from '../models/car-rent-post-dto';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  constructor(private readonly http: HttpClient){}
  
  load() :Observable<CarsGetDto[]>{
    return this.http.get<CarsGetDto[]>('http://localhost:5000/api/CarRental/cars');
  }

  loadCarById(id: number): Observable<CarsGetDto>{
    return this.http.get<CarsGetDto>(`http://localhost:5000/api/CarRental/car/${id}`);
  }

  modify(dto: CarsGetDto): Observable<{ message: string }>{
    return this.http.put<{ message: string }>('',dto);  //<< be kell irni az endpointot
  }

  servicing(dto: CarRentPostDto): Observable<{ message: string }>{
    return this.http.post<{ message: string }>('', dto); //<<path et irdd be
  }
}
