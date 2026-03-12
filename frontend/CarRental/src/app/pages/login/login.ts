import { Component } from '@angular/core';
import { NgForm, FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { LoginUserDto } from '../../models/login-user-dto';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {

  constructor(
    private readonly router: Router,
    private readonly userService: UserService
  ){}

  getForm(userForm: NgForm){
    const user = userForm.value as unknown as LoginUserDto
    this.userService.login(user).subscribe({
      next: (res) => {
        this.router.navigate(['deshboard']);
      },
      error: (err) => {
        const msg = err?.error?.message || 'Login failed';
        console.error('Login failed:', msg);
        alert(msg);
      }
    });
  }
}
