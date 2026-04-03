import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { CarService } from '../../services/car.service';
import { CarsGetDto } from '../../models/cars-get-dto';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-admin-car-list',
  imports: [CommonModule],
  templateUrl: './admin-car-list.html',
  styleUrl: './admin-car-list.scss',
})
export class AdminCarList {

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

  navigateCarModify(carId: number){
    this.router.navigate(['admin-car-modify', carId]);
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

  navigateServicing(id: number){
    this.router.navigate(['admin-servicin', id]);
  }

  deleteCar(carId: number){
    this.carService.delete(carId).subscribe({
      next: (res) => {
        this.changedetector.detectChanges();
        this.router.navigate(['deshboard']);
      },
      error: (err) => {
        console.error(err.error.message);
      }
    });
  }
}
