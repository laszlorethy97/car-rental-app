import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { CarService } from '../../services/car.service';
import { CarsGetDto } from '../../models/cars-get-dto';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-general-car-list',
  imports: [CommonModule],
  templateUrl: './general-car-list.html',
  styleUrl: './general-car-list.scss',
})
export class GeneralCarList {

  constructor(
    private readonly location: Location,
    private readonly router: Router,
    private readonly carService: CarService,
    private readonly changedetector: ChangeDetectorRef
  ){}

    cars: CarsGetDto[] = [];
    ngOnInit(){
      this.loadCars();
    }

    navigateBack(){
      this.location.back();
    }

    navigateRent(carId: number){
      this.router.navigate(['general-rent-car', carId]);
    }

    loadCars(){
      this.carService.load().subscribe({
        next: (res) => {
          this.cars = res;
          this.changedetector.detectChanges();
        },
        error: (err) => {
          console.error('the cars cant load', err.message)
        }
      });
    }
}
