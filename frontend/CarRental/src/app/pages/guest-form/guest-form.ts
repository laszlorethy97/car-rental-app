import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { GuestRentCarDto } from '../../models/guest-rent-car-dto';

@Component({
  selector: 'app-guest-form',
  imports: [FormsModule, CommonModule],
  templateUrl: './guest-form.html',
  styleUrl: './guest-form.scss',
})
export class GuestForm {
  carId!: number;

  constructor(
    private readonly activatedRoute: ActivatedRoute
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
      addres: userForm.value.address,
      telephon: userForm.value.phone,
      startDate: userForm.value.startDate,
      endDate: userForm.value.endDate
    }
    console.log(dto);

  }

  catchId(){
    this.activatedRoute.paramMap.subscribe(params =>{
      this.carId = Number(params.get('id'));
    });
  }
}
