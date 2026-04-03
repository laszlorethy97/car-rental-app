import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { Role } from '../../models/role';
import { UserService } from '../../services/user.service';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  imports: [],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class Dashboard {

  roles: Role[] = []

  constructor(
    private readonly router: Router,
    private readonly authService: AuthService,
    private readonly userService: UserService,
    private readonly changeDetector: ChangeDetectorRef
  ){}

  hasRole(role: string): boolean{
    return this.roles.some(r => r.roleType == role)
  }

  ngOnInit(){
    this.loadRoles();
  }
  loadRoles(){
    this.userService.roles().subscribe({
      next: (res) => {
        this.roles = res;
        console.log(this.roles);
        this.changeDetector.detectChanges();
      },
      error: (err) => {
        console.error(err.error.message);
      }
    });
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



