import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { CarRentPostDto } from '../../models/car-rent-post-dto';
import { ActivatedRoute } from '@angular/router';
import { RentalService } from '../../services/rental.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-general-rent-car',
  imports: [CommonModule, FormsModule],
  templateUrl: './general-rent-car.html',
  styleUrl: './general-rent-car.scss',
})
export class GeneralRentCar {
  carId!: number;

  constructor(
    private readonly activeRoute: ActivatedRoute,
    private readonly rentalService: RentalService,
    private readonly router: Router
  ){}

  ngOnInit(){
    this.catchCarId();
  }

  catchCarId(){
    this.activeRoute.paramMap.subscribe(params => {
      this.carId = Number(params.get('id')); 
    });
  }

  getForm(carForm: NgForm){
    const carRentPostDto: CarRentPostDto = {carId: this.carId, startDate: carForm.value.startDate, endDate: carForm.value.endDate};
    this.rentalService.rent(carRentPostDto).subscribe({
      next: (res) => {
        this.router.navigate(['deshboard']);
      },
      error: (err) => {
        const msg = err?.error?.message;
        console.error(msg);
        alert(msg);
      }
    });
  }
}
