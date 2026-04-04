import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GuestRentCarDto } from '../../models/guest-rent-car-dto';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-guest-form',
  imports: [FormsModule, CommonModule],
  templateUrl: './guest-form.html',
  styleUrl: './guest-form.scss',
})
export class GuestForm {
  carId!: number;

  constructor(
    private readonly activatedRoute: ActivatedRoute,
    private readonly userService: UserService,
    private readonly router: Router
  ){}

  ngOnInit(){
    this.catchId();
  }
  getForm(userForm: NgForm){
    const dto: GuestRentCarDto = {
      carId: this.carId,
      email: userForm.value.email,
      firstName: userForm.value.firstname,
      lastName: userForm.value.lastname,
      address: userForm.value.address,
      phoneNumber: userForm.value.phone,
      startDate: userForm.value.startDate,
      endDate: userForm.value.endDate
    }
    this.userService.guestRent(dto).subscribe({
      next: (res) => {
        alert("your rental is success!");
        this.router.navigate(['']);
      },
      error: (err) => {
        console.error(err.error.message);
        alert(err.error.message);
      }
    });

  }

  catchId(){
    this.activatedRoute.paramMap.subscribe(params =>{
      this.carId = Number(params.get('id'));
    });
  }
}
