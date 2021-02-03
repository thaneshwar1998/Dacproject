import { AuthGuardService } from './../auth-guard.service';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Authentication } from '../authentication.service';
import { Login } from './Login.module';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login=new Login();
  loginform=new FormGroup({
    UserName:new FormControl('',[Validators.required,Validators.email]),
    Password:new FormControl('',[Validators.required,Validators.minLength(5)])
  })
 /* alert:boolean=false;
  UserName:string;
  Password:string;*/
  invalidLogin:boolean;

  constructor(private auth:Authentication,private formbuilder:FormBuilder,private router:Router,
              )
  { }

  ngOnInit() {}

  verifyUserLogin(){

      this.auth.login
      (this.login.UserName,this.login.Password).subscribe(
        response => {
          console.log(`auth resp ${response}`);
          if(response)
          {
            this.invalidLogin = false;
            console.log(response)
            sessionStorage['email']=this.login.UserName;
            alert("Logged Sucessfully")

             this.router.navigate(['']);
          }
          else
          {
            alert("invalid login credentials")
            this.router.navigate(['/login'])
          }

        },
        error => {
          alert("invalid login....");
          this.invalidLogin = true;
        }
      );


  }
  /*
  onLogin() {
    if (this.email.length == 0) {
      this.toastr.error('please enter email')
    } else if (this.password.length == 0) {
      this.toastr.error('please enter password')
    } else {
      this.authService
        .login(this.email, this.password)
        .subscribe(response => {
          if (response['status'] == 'success') {
            const data = response['data']
            console.log(data)

            // cache the user info
            sessionStorage['empid'] = data['empid']
            sessionStorage['role'] = data['role']
            sessionStorage['name'] = data['user_name']

            this.toastr.success(`Welcome ${data['user_name']} to TMS`)

            // goto the dashboard
            this.router.navigate(['/home'])

          } else {
            alert(response['message'])
          }
        })*/


}
/*
serName: string;
  password: string;
  invalidLogin: boolean;
  constructor(private authService: AuthServiceService, private router: Router
  ) {

  }

  ngOnInit() {
  }
  verifyUserLogin() {
    this.authService.authenticate
    (this.userName, this.password).subscribe(
      response => {
        console.log(`auth resp ${response}`);
        // for (let u of response)
        //   console.log(`User ${u.id} ${u.name}`);
        this.invalidLogin = false;
        this.router.navigate(['']);
      },
      error => {
        alert("invalid login....");
        this.invalidLogin = true;
      }
    );

  }*/
