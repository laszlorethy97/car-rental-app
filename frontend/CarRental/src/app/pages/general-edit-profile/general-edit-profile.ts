import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';
import { EditProfileGetDto } from '../../models/edit-profile-get-dto';
import { ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-general-edit-profile',
  imports: [FormsModule, CommonModule],
  templateUrl: './general-edit-profile.html',
  styleUrl: './general-edit-profile.scss',
})
export class GeneralEditProfile {

  user: EditProfileGetDto = {
    email: '',
    password: '',
    userName: '',
    firstName: '',
    lastName: '',
    phoneNumber: '',
    address: ''
  };

  constructor(
    private readonly userservice: UserService,
    private readonly changeDetector: ChangeDetectorRef,
    private readonly router: Router
  ){}

  ngOnInit(){
    this.loadUser();
  }
  
  loadUser(){
    this.userservice.load().subscribe({
      next: (res) =>{
        this.user = res
        this.changeDetector.detectChanges();
      },
      error: (err) =>{
        console.error('Error loading the user:', err);
      }
    });
  }


  getForm(userForm: NgForm){
    const user = userForm.value as unknown as EditProfileGetDto
    this.userservice.edit(user).subscribe({
      next: (res) => {
        this.router.navigate(['deshboard']);
      },
      error: (err) => {
        console.error(err.message);
      }
    });
  }
}
