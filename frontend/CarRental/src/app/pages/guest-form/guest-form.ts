import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-guest-form',
  imports: [FormsModule, CommonModule],
  templateUrl: './guest-form.html',
  styleUrl: './guest-form.scss',
})
export class GuestForm {

  getForm(userForm: NgForm){
    console.log(userForm.value);
  }
}
