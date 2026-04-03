import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegistrationUserDto } from '../models/registration-user-dto';
import { EditProfileGetDto } from '../models/edit-profile-get-dto';
import { Role } from '../models/role';

@Injectable({
  providedIn: 'root',

})
export class UserService {
  constructor(private readonly httpclient: HttpClient){}

  registration(user: RegistrationUserDto): Observable<{ message: string }>{
    return this.httpclient.post<{ message: string }>('http://localhost:5000/api/CarRental/user/registration', user);
  }

  load(): Observable<EditProfileGetDto>{
    return this.httpclient.get<EditProfileGetDto>('http://localhost:5000/api/CarRental/user/name/');
  }

  edit(user: EditProfileGetDto): Observable<{ message: string }>{
    return this.httpclient.put<{ message: string}>('http://localhost:5000/api/CarRental/user/editProfile',user);
  }

  roles(): Observable<Role[]>{
    return this.httpclient.get<Role[]>('http://localhost:5000/api/CarRental/user/get-roles')
  }
}
