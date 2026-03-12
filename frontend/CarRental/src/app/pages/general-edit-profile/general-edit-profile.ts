import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';
import { EditProfileGetDto } from '../../models/edit-profile-get-dto';
import { ChangeDetectorRef } from '@angular/core';

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
    private readonly changeDetector: ChangeDetectorRef
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

  }
}
