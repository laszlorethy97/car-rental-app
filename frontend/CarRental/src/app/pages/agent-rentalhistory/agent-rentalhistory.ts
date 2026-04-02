import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { RentalService } from '../../services/rental.service';
import { RentIdToInvoiceDto } from '../../models/rent-id-to-invoice-dto';
import { GetAllRentalsDto } from '../../models/get-all-rentals-dto';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-agent-rentalhistory',
  imports: [CommonModule],
  templateUrl: './agent-rentalhistory.html',
  styleUrl: './agent-rentalhistory.scss',
})
export class AgentRentalhistory {

  rentals: GetAllRentalsDto [] = [];

  constructor (
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

  navigateBack(){
    this.location.back();
  }

  navigateToAddInvoice(id: number){
    const dto: RentIdToInvoiceDto = {rentId: id}
    this.rentalService.makeInvoice(dto).subscribe({
      next: (res) =>{
        console.log('siker');
        this.router.navigate(['add-invoice', id]);
      },
      error: (err) => {
        console.error('error: ', err.error.message);
        alert(err.error.message);
      }
    });
  }

  navigateToModify(id: number){
    this.router.navigate(['invoice-modify', id]);
  }

  navigateToCloseRental(id: number){
    this.router.navigate(['close-rental', id]);
  }

  activate(id: number){
    const dto: RentIdToInvoiceDto = {rentId: id}
    this.rentalService.activate(dto).subscribe({
      next: (res) =>{
        this.router.navigate(['deshboard']);
      },
      error: (err) => {
        console.error('error: ', err.error.message);
        alert(err.error.message);
      }
    });
  }
}

