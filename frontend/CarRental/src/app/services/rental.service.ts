import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarRentPostDto } from '../models/car-rent-post-dto';
import { RentalHistoryDto } from '../models/rental-history-dto';
import { RentIdToInvoiceDto } from '../models/rent-id-to-invoice-dto';
import { GetAllRentalsDto } from '../models/get-all-rentals-dto';
import { RentalDecisionPutDto } from '../models/rental-decision-put-dto';

@Injectable({
  providedIn: 'root',
})
export class RentalService {
  constructor(private readonly httpClient: HttpClient){}

  rent(rental: CarRentPostDto): Observable<{message: string}>{
    return this.httpClient.post<{message: string}>('http://localhost:5000/api/CarRental/rental/rental', rental);
  }

  load(): Observable<RentalHistoryDto[]>{
    return this.httpClient.get<RentalHistoryDto[]>('http://localhost:5000/api/CarRental/rental/history');
  }

  makeInvoice(dto: RentIdToInvoiceDto): Observable<{message: string}>{
    return this.httpClient.post<{message: string}>('http://localhost:5000/api/CarRental/invoice', dto);
  }

  getAllRentals(): Observable<GetAllRentalsDto[]>{
    return this.httpClient.get<GetAllRentalsDto[]>('http://localhost:5000/api/CarRental/rental/rentals');
  }

  modify(dto: RentalDecisionPutDto): Observable<{message: string}>{
    return this.httpClient.put<{message: string}>('http://localhost:5000/api/CarRental/rental/modify',dto)
  }

  close(dto: RentalDecisionPutDto): Observable<{message: string}>{
    return this.httpClient.put<{message: string}>('http://localhost:5000/api/CarRental/rental/close',dto)
  }

  activate(dto: RentIdToInvoiceDto): Observable<{message: string}>{
    return this.httpClient.post<{message: string}>('http://localhost:5000/api/CarRental/rental/activate', dto);
  }

  adminModify(dto: RentalDecisionPutDto): Observable<{message: string}>{
    return this.httpClient.put<{message: string}>('http://localhost:5000/api/CarRental/rental/modify',dto) //todo a path
  }
}
