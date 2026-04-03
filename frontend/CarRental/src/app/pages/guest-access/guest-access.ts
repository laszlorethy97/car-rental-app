import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { CarService } from '../../services/car.service';
import { ChangeDetectorRef } from '@angular/core';
import { CarsGetDto } from '../../models/cars-get-dto';

@Component({
  selector: 'app-guest-access',
  imports: [CommonModule],
  templateUrl: './guest-access.html',
  styleUrl: './guest-access.scss',
})
export class GuestAccess {
  cars: CarsGetDto[] = [];

  constructor(
    private readonly router: Router,
    private readonly carService: CarService,
    private readonly changedetector: ChangeDetectorRef
  ){}
  ngOnInit(){
    this.loadCars();
  }

  loadCars(){
    this.carService.load().subscribe({
      next: (res) => {
        this.cars = res;
        console.log(this.cars);
        this.changedetector.detectChanges();
      },
      error: (err) => {
        console.error('the cars cant load', err.message)
      }
    });
  }

  navigateForm(id: number){
    this.router.navigate(['guest-form',id]);
  }
}

