import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  imports: [],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class Dashboard {
  constructor(private readonly router: Router){}

  navigateToRentalHistory(){
    this.router.navigate(['general-rental-history']);
  }

  navigateToCars(){
    this.router.navigate(['general-car-list']);
  }
  
  navigateToEditProfile(){
    this.router.navigate(['general-edit-profile']);
  }
}
