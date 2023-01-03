import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ForgotPasswordDto } from '../models/forgotPasswordDto.model';
import { ResetPasswordDto } from '../models/resetPasswordDto.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private loginUrl: string = "https://localhost:7184/api/Account/login";
  private googleUrl: string = "https://localhost:7184/api/Account/googleLogin";
  constructor(private http: HttpClient) { }


  
  login(loginObj: any) {
    return this.http.post<any>(`${this.loginUrl}`, loginObj);
  }

  googleLogin(email: string) {
    return this.http.post<string>(`${this.googleUrl}`, email);
  }

  public forgotPassword = (body: ForgotPasswordDto) => {
    return this.http.post("https://localhost:7184/api/Account/ForgotPassword", body);
  }

  public resetPassword = (body: ResetPasswordDto) => {;
    return this.http.post("https://localhost:7184/api/Account/ResetPassword", body);
  }

}


