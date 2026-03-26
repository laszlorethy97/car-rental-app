import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rental-modify',
  imports: [CommonModule, FormsModule],
  templateUrl: './rental-modify.html',
  styleUrl: './rental-modify.scss',
})
export class RentalModify {

  constructor(
    private readonly router:Router
  ){}
  getForm(form :NgForm){
    console.log(form.value);
  }

  navigateBack(){
    this.router.navigate(['deshboard']);
  }
}
