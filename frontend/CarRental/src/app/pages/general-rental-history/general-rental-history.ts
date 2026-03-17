import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Location } from '@angular/common';

@Component({
  selector: 'app-general-rental-history',
  imports: [CommonModule],
  templateUrl: './general-rental-history.html',
  styleUrl: './general-rental-history.scss',
})
export class GeneralRentalHistory {

  constructor(private readonly location: Location){}
  //rentalHistory$ = this.rentalService.getRentalHistory(); ->kesobb igy oldjuk meg hogy szep aszinkron legyen
  //<li *ngFor="let rental of rentalHistory$ | async as dto"> -> HTML be meg igy hivatkozzuk majd
  rentals: Rental[] = [
    {price: '1950', start: new Date('1997-08-04'), end: new Date('1997-08-24')},
    {price: '1950', start: new Date('1997-08-04'), end: new Date('1997-08-24')},
    {price: '1950', start: new Date('1997-08-04'), end: new Date('1997-08-24')},
  ];

  navigateBack(){
    this.location.back();
  }
}

interface Rental{
  price: string,
  start: Date,
  end: Date
}
