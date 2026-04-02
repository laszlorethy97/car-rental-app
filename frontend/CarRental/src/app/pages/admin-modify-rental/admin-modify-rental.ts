import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { RentalService } from '../../services/rental.service';
import { ActivatedRoute } from '@angular/router';
import { RentalDecisionPutDto } from '../../models/rental-decision-put-dto';

@Component({
  selector: 'app-admin-modify-rental',
  imports: [CommonModule, FormsModule],
  templateUrl: './admin-modify-rental.html',
  styleUrl: './admin-modify-rental.scss',
})
export class AdminModifyRental {
  rentalId!: number
  constructor(
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router,
    private readonly rentalService: RentalService
  ){}


  ngOnInit(){
    this.catchRentalId();
  }

  catchRentalId(){
    this.activatedRoute.paramMap.subscribe(params =>{
      this.rentalId = Number(params.get('id'));
    });
  }


  getForm(form :NgForm){
    const rental: RentalDecisionPutDto = {rentalId: this.rentalId ,answer: form.value.answer};
    this.rentalService.adminModify(rental).subscribe({
      next: (res) => {
        this.router.navigate(['deshboard']);
      },
      error: (err) => {
        console.error(err.error.message);
        alert(err.error.message);
      }
    });
  }

  navigateBack(){
    this.router.navigate(['deshboard']);
  }


}
