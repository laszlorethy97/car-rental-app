import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-guest-access',
  imports: [CommonModule],
  templateUrl: './guest-access.html',
  styleUrl: './guest-access.scss',
})
export class GuestAccess {

  constructor(private readonly router: Router){}

  cars: Car[] = [
    { brand: 'Toyota', model: 'Corolla', year: 2020, description: 'Ez egy nagyon hosszú szöveg, ami biztosan nem fér el a dobozban, így scrollozható lesz.' },
    { brand: 'Honda', model: 'Civic', year: 2019, description: 'Rövid szöveg.' },
    { brand: 'Ford', model: 'Focus', year: 2018, description: 'Még egy hosszú szöveg példa, hogy látszódjon a scroll.' },
    { brand: 'Ford', model: 'Focus', year: 2018, description: 'Még egy hosszú szöveg példa, hogy látszódjon a scroll.' },
    { brand: 'Ford', model: 'Focus', year: 2018, description: 'Még egy hosszú szöveg példa, hogy látszódjon a scroll.' },
    { brand: 'Ford', model: 'Focus', year: 2018, description: 'Még egy hosszú szöveg példa, hogy látszódjon a scroll.' },
    { brand: 'Ford', model: 'Focus', year: 2018, description: 'Még egy hosszú szöveg példa, hogy látszódjon a scroll.' },
    { brand: 'Ford', model: 'Focus', year: 2018, description: 'Még egy hosszú szöveg példa, hogy látszódjon a scroll.' },
    { brand: 'Ford', model: 'Focus', year: 2018, description: 'Még egy hosszú szöveg példa, hogy látszódjon a scroll.' },
    { brand: 'Ford', model: 'Focus', year: 2018, description: 'Még egy hosszú szöveg példa, hogy látszódjon a scroll.' },
    { brand: 'Ford', model: 'Focus', year: 2018, description: 'Még egy hosszú szöveg példa, hogy látszódjon a scroll.' },
    { brand: 'Ford', model: 'Focus', year: 2018, description: 'Még egy hosszú szöveg példa, hogy látszódjon a scroll.' },
    { brand: 'Ford', model: 'Focus', year: 2018, description: 'Még egy hosszú szöveg példa, hogy látszódjon a scroll.' },
  ];

  navigateForm(){
    this.router.navigate(['guest-form']);
  }
}

export interface Car {
  brand: string;
  model: string;
  year: number;
  description: string;
}
