import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarsGetDto } from '../models/cars-get-dto';
import { CarRentPostDto } from '../models/car-rent-post-dto';
import { CreateCarDTO } from '../models/create-car-dto';
import { MaintancePostDto } from '../models/maintance-post-dto';

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
    return this.http.put<{ message: string }>('http://localhost:5000/api/CarRental/admin-car-modify',dto);
  }

  servicing(dto: MaintancePostDto): Observable<{ message: string }>{
    return this.http.post<{ message: string }>('http://localhost:5000/api/CarRental/admin-maintenance-modify', dto);
  }

  add(dto: CreateCarDTO): Observable<{ message: string }>{
    return this.http.post<{ message: string }>('http://localhost:5000/api/CarRental/car', dto);
  }

  delete(id: number): Observable<{ message: string }>{
    return this.http.delete<{ message: string }>(`http://localhost:5000/api/CarRental/admin-car-delete/${id}`);
  }
}
