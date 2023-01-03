import { GoogleLoginProvider, SocialAuthService, SocialUser } from '@abacritt/angularx-social-login';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from './../services/login.service';
import { MsalService } from '@azure/msal-angular';
import { AuthenticationResult } from '@azure/msal-browser';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  type: string="password";
  isText:boolean=false;
  eyeIcon: string ="fa-regular fa-eye-slash "
   
  loginForm!:FormGroup
  title='formvalidation';
  submitted = false;
  user: any;
  loggedIn: any;
  googleUser: SocialUser;
  private userObject;

  constructor(private formbuilder: FormBuilder, private login: LoginService, private router: Router, private msService: MsalService, private authService: SocialAuthService, private httpClient: HttpClient) { }

  
 
 
 ngOnInit():void{
   this.loginForm = this.formbuilder.group({
     userName: ['', Validators.required],
     password: ['', Validators.required]
     

   });
   this.authService.authState.subscribe((user) => {
     localStorage.setItem('userObject', JSON.stringify(user));
     this.user = user;
     this.loggedIn = (user != null);
     console.log(this.user);
     //localStorage.getItem('userObject');
     this.userObject = JSON.parse( localStorage.getItem('userObject'));
     console.log(this.userObject.email);
   });
   
 }
  showPassword(){
    this.isText= !this.isText;
    this.isText? this.eyeIcon=" fa regular fa-eye": this.eyeIcon="fa-regular fa-eye-slash";
    this.isText? this.type = "text":this.type="password";
  }

  onSubmit() {
    this.submitted = true
    if (this.loginForm.invalid) {
      return

    }
    console.log(this.loginForm);

    this.login.login(this.loginForm.value)
      .subscribe({
        next: (res) => {
          alert(res.message)
          this.loginForm.reset();
          this.router.navigate(['dashboard']);
        },
        error: (err) => {
          alert(err?.error.message)
        }
        })
  }

  googleLogin() {
    //if (this.login.googleLogin(this.userObject.email)) {
    //  this.router.navigate(['dashboard']);
    //}
    //else {
    //  alert("User doesn't exist!");
    //}
    this.login.googleLogin(this.userObject.email)
      .subscribe({
        next: () => {
          console.log(this.userObject.email)
          this.router.navigate(['dashboard']);
        },
        error: (err) => {
          alert(err?.error.message)
        }
      })
    
  }

  isLoggedIn(): boolean {
    return this.msService.instance.getActiveAccount()!= null
  }

  msLogin() {
    this.msService.loginPopup()
      .subscribe((response: AuthenticationResult) => {
        this.msService.instance.setActiveAccount(response.account);
        this.router.navigate(['dashboard']);
      });
  }
}
