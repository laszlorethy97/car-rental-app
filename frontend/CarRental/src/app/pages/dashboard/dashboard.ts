import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { Role } from '../../models/role';

@Component({
  selector: 'app-dashboard',
  imports: [],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class Dashboard {

  roles: Role[] = [
    {roleType: "agent"},
    {roleType: "admin"},
  ]

  constructor(
    private readonly router: Router,
    private readonly authService: AuthService
  ){}

  hasRole(role: string): boolean{
    return this.roles.some(r => r.roleType == role)
  }

  navigateToRentalHistory(){
    this.router.navigate(['general-rental-history']);
  }

  navigateToCars(){
    this.router.navigate(['general-car-list']);
  }
  
  navigateToEditProfile(){
    this.router.navigate(['general-edit-profile']);
  }
  navigateToAgentRentalHistory(){
    this.router.navigate(['agent-rental-history']);
  }

  navigateToAdminRentalHistory(){
    this.router.navigate(['admin-rental-history']);
  }

  navigateToAdminCarsList(){
    this.router.navigate(['admin-car-list']);
  }

  logOut(){
    this.authService.logout();
    this.router.navigate(['']);
  }

  navigateToAdminAddNewCar(){
    this.router.navigate(['admin-add-new-car']);
  }
}



