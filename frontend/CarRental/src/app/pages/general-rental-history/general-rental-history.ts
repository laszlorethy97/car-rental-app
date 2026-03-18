import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Location } from '@angular/common';
import { RentalService } from '../../services/rental.service';
import { RentalHistoryDto } from '../../models/rental-history-dto';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-general-rental-history',
  imports: [CommonModule],
  templateUrl: './general-rental-history.html',
  styleUrl: './general-rental-history.scss',
})
export class GeneralRentalHistory {
  rentals: RentalHistoryDto[] = [];

  constructor(
    private readonly location: Location,
    private readonly rentalService: RentalService,
    private readonly changedetector: ChangeDetectorRef
  ){}
 
  ngOnInit(){
    this.loadRentals();
  }

  loadRentals(){
    this.rentalService.load().subscribe({
      next: (res) =>{
        this.rentals = res;
        this.changedetector.detectChanges();
      },
      error: (err) => {
        console.error(err.message);
      }
    });
  }

  navigateBack(){
    this.location.back();
  }
}

