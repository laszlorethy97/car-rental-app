import { Component } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-welcome',
  imports: [],
  templateUrl: './welcome.html',
  styleUrl: './welcome.scss',
})
export class Welcome {

  constructor(private readonly router: Router){}

  navigateToRegisterComponent(){
    this.router.navigate(['register']);
  }

  navigateToLoginComponent(){
    this.router.navigate(['login']);
  }

  navigateToGuesAccessComponent(){
    this.router.navigate(['guest-access']);
  }
}
