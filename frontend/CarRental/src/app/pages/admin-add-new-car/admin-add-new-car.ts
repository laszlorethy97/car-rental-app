import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CreateCarDTO } from '../../models/create-car-dto';
import { Router } from '@angular/router';
import { CarService } from '../../services/car.service';


@Component({
  selector: 'app-admin-add-new-car',
  imports: [FormsModule, CommonModule],
  templateUrl: './admin-add-new-car.html',
  styleUrl: './admin-add-new-car.scss',
})
export class AdminAddNewCar {
  

  constructor(
    private readonly router: Router,
    private readonly carService: CarService,
  ){}

  getForm(form: NgForm){
    const car: CreateCarDTO = form.value as unknown as CreateCarDTO
    console.log(car);
    this.carService.add(car).subscribe({
      next: (res) => {
        this.router.navigate(['deshboard']);
      },
      error: (err) => {
        console.error(err.error.message);
      }
    });
  }

}
