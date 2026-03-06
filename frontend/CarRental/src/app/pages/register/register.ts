import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  imports: [FormsModule, CommonModule],
  templateUrl: './register.html',
  styleUrl: './register.scss',
})
export class Register {

  constructor(private readonly router: Router){}

  getForm(user: NgForm){
    console.log(user.value);
    this.router.navigate(['deshboard']);
  }
}
