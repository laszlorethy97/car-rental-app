import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegistrationUserDto } from '../models/registration-user-dto';
import { LoginUserDto } from '../models/login-user-dto';

@Injectable({
  providedIn: 'root',

})
export class UserService {
  constructor(private readonly httpclient: HttpClient){}

  registration(formValue: any): Observable<{ message: string }>{
    const user:RegistrationUserDto = this.buildRegistrationDTO(formValue);
    return this.httpclient.post<{ message: string }>('http://localhost:5000/api/CarRental/user/registration', user);
  }

  buildRegistrationDTO(formValue: any): RegistrationUserDto {
    return {
      email: formValue.email,
      password: formValue.password,
      userName: formValue.userName,
      firstName: formValue.firstName,
      lastName: formValue.lastName,
      phoneNumber: formValue.phoneNumber,
      address: formValue.address,
      roleIds: [1]
    };
  }

  login(formValue: any): Observable<{ message: string }>{
    const user: LoginUserDto = this.buildLoginUserDto(formValue);
    return this.httpclient.post<{ message: string }>('http://localhost:5000/api/CarRental/user/login', user);
  }

  buildLoginUserDto(formValue: any): LoginUserDto{
    return{
      userName: formValue.userName,
      password: formValue.password
    }
  }
}
