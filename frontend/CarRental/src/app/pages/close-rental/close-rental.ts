import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { RentalService } from '../../services/rental.service';
import { RentalDecisionPutDto } from '../../models/rental-decision-put-dto';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-close-rental',
  imports: [CommonModule, FormsModule],
  templateUrl: './close-rental.html',
  styleUrl: './close-rental.scss',
})
export class CloseRental {
  rentalId! :number;

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

  navigateBack(){
    this.router.navigate(['deshboard']);
  }

  getForm(form :NgForm){
    const rental: RentalDecisionPutDto = {rentalId: this.rentalId ,answer: form.value.answer};
    this.rentalService.close(rental).subscribe({
      next: (res) => {
        this.router.navigate(['deshboard']);
      },
      error: (err) => {
        console.error(err.error.message);
        alert(err.error.message);
      }
    });
  }

}
