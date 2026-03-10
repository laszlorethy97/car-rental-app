import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-general-car-list',
  imports: [CommonModule],
  templateUrl: './general-car-list.html',
  styleUrl: './general-car-list.scss',
})
export class GeneralCarList {

  constructor(
    private readonly location: Location,
    private readonly router: Router
  ){}

  cars: Car[] = [
      { brand: 'Toyota', model: 'Corolla', year: 2020, description: 'Ez egy nagyon hosszú szöveg, ami biztosan nem fér el a dobozban, így scrollozható lesz.' },
      { brand: 'Honda', model: 'Civic', year: 2019, description: 'Rövid szöveg.' },
      { brand: 'Ford', model: 'Focus', year: 2018, description: 'Még egy hosszú szöveg példa, hogy látszódjon a scroll.' },

    ];

    navigateBack(){
      this.location.back();
    }

    navigateRent(){
      this.router.navigate(['general-rent-car']);
    }
}

export interface Car {
  brand: string;
  model: string;
  year: number;
  description: string;
}