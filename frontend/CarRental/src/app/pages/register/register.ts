import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';
import { RegistrationUserDto } from '../../models/registration-user-dto';

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

  getForm(form: NgForm) {
    const user = form.value as unknown as RegistrationUserDto
    this.userService.registration(user).subscribe({
      next: (res) => {
        this.router.navigate(['login']);
      },
      error: (err) => {
        const msg = err?.error?.message || 'Registration failed';
        console.error('Registration failed:', msg);
        alert(msg);
      }
    });
  }
}
