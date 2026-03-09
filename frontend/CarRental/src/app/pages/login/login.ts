import { Component } from '@angular/core';
import { NgForm, FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';

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

  getForm(user: NgForm){
    console.log(user.value);
    this.userService.login(user.value).subscribe({
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
