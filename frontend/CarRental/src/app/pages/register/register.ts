import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-register',
  imports: [FormsModule, CommonModule],
  templateUrl: './register.html',
  styleUrl: './register.scss',
})
export class Register {

  constructor(
    private readonly router: Router,
    private readonly userService: UserService
  ){}

  getForm(user: NgForm) {
    this.userService.registration(user.value).subscribe({
      next: (res) => {
        this.router.navigate(['deshboard']);
      },
      error: (err) => {
        const msg = err?.error?.message || 'Registration failed';
        console.error('Registration failed:', msg);
        alert(msg);
      }
    });
  }
}
