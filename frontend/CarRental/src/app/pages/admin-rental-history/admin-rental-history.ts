import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { RentalService } from '../../services/rental.service';
import { RentIdToInvoiceDto } from '../../models/rent-id-to-invoice-dto';
import { GetAllRentalsDto } from '../../models/get-all-rentals-dto';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-admin-rental-history',
  imports: [CommonModule],
  templateUrl: './admin-rental-history.html',
  styleUrl: './admin-rental-history.scss',
})
export class AdminRentalHistory {
  rentals: GetAllRentalsDto [] = [];

  constructor(
    private readonly location: Location,
    private readonly router:Router,
    private readonly rentalService: RentalService,
    private readonly changeDetector: ChangeDetectorRef
  ){}

  ngOnInit(){
    this.getRentals();
  }

  getRentals(){
    this.rentalService.getAllRentals().subscribe({
      next: (res) => {
        this.rentals = res;
        this.changeDetector.detectChanges();
      },
      error: (err) => {
        console.error(err.error.message);
      }
    });
  }
  navigateModify(id: number){
    this.router.navigate(['admin-modify-rental', id]);
  }

  navigateBack(){
    this.location.back();
  }
}
