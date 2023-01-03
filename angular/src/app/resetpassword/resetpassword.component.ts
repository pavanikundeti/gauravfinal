import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators} from '@angular/forms';
import { LoginService } from '../services/login.service';
import { PasswordConfirmationValidatorService } from '../services/password-confirmation-validator.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ResetPasswordDto } from '../models/resetPasswordDto.model';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-resetpassword',
  templateUrl: './resetpassword.component.html',
  styleUrls: ['./resetpassword.component.css']
})
export class ResetpasswordComponent {
  resetPasswordForm: FormGroup;
  showSuccess: boolean;
  showError: boolean;
  errorMessage: string;

  private token: string;
  private email: string;

  constructor(private loginService: LoginService, private passConfValidator: PasswordConfirmationValidatorService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.resetPasswordForm = new FormGroup({
      password: new FormControl('', [Validators.required]),
      confirm: new FormControl('')
    });

    this.resetPasswordForm.get('confirmpassword').setValidators([Validators.required,
      this.passConfValidator.validateConfirmPassword(this.resetPasswordForm.get('password'))]);

    this.token = this.route.snapshot.queryParams['token'];
    this.email = this.route.snapshot.queryParams['email'];
  }

  public validateControl = (controlName: string) => {
    return this.resetPasswordForm.get(controlName).invalid && this.resetPasswordForm.get(controlName).touched
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.resetPasswordForm.get(controlName).hasError(errorName)
  }

  public resetPassword = (resetPasswordFormValue) => {
    this.showError = this.showSuccess = false;
    const resetPass = { ...resetPasswordFormValue };

    const resetPassDto: ResetPasswordDto = {
      password: resetPass.password,
      confirmPassword: resetPass.confirmpassword,
      token: this.token,
      email: this.email
    }

    this.loginService.resetPassword(resetPassDto)
      .subscribe({
        next: (_) => {
          this.showSuccess = true
          this.router.navigate(['login'])
        },
        
        
        error: (err: HttpErrorResponse) => {
          this.showError = true;
          this.errorMessage = err.message;
        }
        })
  }
 
}
