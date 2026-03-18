import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-dashboard',
  imports: [],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class Dashboard {
  constructor(
    private readonly router: Router,
    private readonly authService: AuthService
  ){}

  navigateToRentalHistory(){
    this.router.navigate(['general-rental-history']);
  }

  navigateToCars(){
    this.router.navigate(['general-car-list']);
  }
  
  navigateToEditProfile(){
    this.router.navigate(['general-edit-profile']);
  }

  logOut(){
    this.authService.logout();
    this.router.navigate(['']);
  }
}
