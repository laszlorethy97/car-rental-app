import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarRentPostDto } from '../models/car-rent-post-dto';

@Injectable({
  providedIn: 'root',
})
export class RentalService {
  constructor(private readonly httpClient: HttpClient){}

  rent(rental: CarRentPostDto): Observable<{message: string}>{
    return this.httpClient.post<{message: string}>('http://localhost:5000/api/CarRental/rental', rental);
  }
}
