import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CarService } from '../../services/car.service';
import { CarsGetDto } from '../../models/cars-get-dto';
import { ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-admin-car-modify',
  imports: [FormsModule, CommonModule],
  templateUrl: './admin-car-modify.html',
  styleUrl: './admin-car-modify.scss',
})
export class AdminCarModify {
  carId! :number

  car: CarsGetDto = {
    id: -1,
    licensePlate: '',
    brand: '',
    model: '',
    year: -1,
    kilometrage: -1,
    rentPrice: -1,
    carStatus: '',
  }

  constructor(
      private readonly carService: CarService,
      private readonly changeDetector: ChangeDetectorRef,
      private readonly router: Router,
      private readonly activatedRoute: ActivatedRoute
  ){}

  ngOnInit(){
    this.catchRentalId();
    this.loadCar();
  }

  catchRentalId(){
    this.activatedRoute.paramMap.subscribe(params =>{
      this.carId = Number(params.get('id'));
    });
  }

  loadCar(){
    this.carService.loadCarById(this.carId).subscribe({
      next: (res) =>{
        this.car = res
        this.changeDetector.detectChanges();
      },
      error: (err) =>{
        console.error('Error loading the car:', err);
      }
    });
  }

  getForm(carForm: NgForm){
    const dto: CarsGetDto = {
      id: this.carId,
      licensePlate: this.car.licensePlate,
      brand: this.car.brand,
      model: this.car.model,
      year: this.car.year,
      kilometrage: this.car.kilometrage,
      rentPrice: this.car.rentPrice,
      carStatus: this.car.carStatus
    }
    this.carService.modify(dto).subscribe({
      next: (res) => {
        this.router.navigate(['deshboard']);
      },
      error: (err) => {
        console.error(err.error.message);
      }
    });

  }

}
