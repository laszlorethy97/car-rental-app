import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-agent-rentalhistory',
  imports: [CommonModule],
  templateUrl: './agent-rentalhistory.html',
  styleUrl: './agent-rentalhistory.scss',
})
export class AgentRentalhistory {
   rentals: Rental[] =  [
    {
      carId: 1,
      startDate: '2026-04-01T10:00:00',
      endDate: '2026-04-03T10:00:00',
      brand: "Toyota",
      model: "Corolla",
      licensePlate: "ABC-123",
      rentStatus: "Requested",
      rentPrice: "15000 Ft"
    },
    {
      carId: 2,
      startDate: '2026-04-05T08:30:00',
      endDate: '2026-04-07T18:00:00',
      brand: "BMW",
      model: "320d",
      licensePlate: "XYZ-789",
      rentStatus: "Approved",
      rentPrice: "30000 Ft"
    }
  ];

  constructor (
    private readonly location: Location,
    private readonly router:Router
  ){}

  navigateBack(){
    this.location.back();
  }

  navigateToAddInvoice(id: number){
    this.router.navigate(['add-invoice', id]);
  }

  navigateToModify(id: number){
    this.router.navigate(['invoice-modify', id]);
  }

  navigateToCloseRental(id: number){
    this.router.navigate(['close-rental', id]);
  }
}

interface Rental{
  carId: number;
  startDate: string;
  endDate: string;
  brand: string;
  model: string;
  licensePlate: string;
  rentStatus: string;
  rentPrice: string;
}
