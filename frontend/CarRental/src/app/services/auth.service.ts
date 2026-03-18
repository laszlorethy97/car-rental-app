import { Injectable } from '@angular/core';
import { LoginUserDto } from '../models/login-user-dto';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  constructor(private readonly httpclient: HttpClient){}

  login(user: LoginUserDto): Observable<{ message: string }>{
    return this.httpclient.post<{ message: string }>('http://localhost:5000/api/CarRental/user/login', user);
  }

  setToken(token: string){
    localStorage.setItem('authToken', token);
  }

  getToken(): string | null{
    return localStorage.getItem('authToken');
  }

  clearToken() {
    localStorage.removeItem('authToken');
  }
}


