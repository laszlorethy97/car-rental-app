import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-invoice',
  imports: [],
  templateUrl: './add-invoice.html',
  styleUrl: './add-invoice.scss',
})
export class AddInvoice {

  constructor(
    private readonly router:Router
  ){}

  navigateBack(){
    this.router.navigate(['deshboard']);
  }
}
