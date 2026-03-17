import { Component } from '@angular/core';
import { NgForm, FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
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
    private readonly authService: AuthService
  ){}

  getForm(userForm: NgForm){
    const user = userForm.value as unknown as LoginUserDto
    this.authService.login(user).subscribe({
      next: (res) => {
        this.authService.setToken(res.message);
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
