import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-close-rental',
  imports: [CommonModule, FormsModule],
  templateUrl: './close-rental.html',
  styleUrl: './close-rental.scss',
})
export class CloseRental {

  constructor(
    private readonly router:Router
  ){}

  navigateBack(){
    this.router.navigate(['deshboard']);
  }

  getForm(rentalForm: NgForm){
    console.log(rentalForm.value);
  }

}
