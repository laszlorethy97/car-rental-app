import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarRentPostDto } from '../models/car-rent-post-dto';
import { RentalHistoryDto } from '../models/rental-history-dto';

@Injectable({
  providedIn: 'root',
})
export class RentalService {
  constructor(private readonly httpClient: HttpClient){}

  rent(rental: CarRentPostDto): Observable<{message: string}>{
    return this.httpClient.post<{message: string}>('http://localhost:5000/api/CarRental/rental', rental);
  }

  load(): Observable<RentalHistoryDto[]>{
    return this.httpClient.get<RentalHistoryDto[]>('http://localhost:5000/api/CarRental/rental/history');
  }
}
