import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup,FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Authentication } from '../authentication.service';
import { Customer } from '../customer.module';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

 
  Customer=new Customer();
  registerForm=new FormGroup(
    {
      Name:new FormControl('',[Validators.required]),
      Email:new FormControl('',[Validators.required,Validators.email]),
      Password:new FormControl('',[Validators.required,Validators.minLength(5)]),
      Address:new FormControl('',[Validators.required]),
      ContactNumber:new FormControl('',[Validators.required,Validators.minLength(10),Validators.maxLength(12)]),
      Role:new FormControl('',[Validators.required]),
    }
  )
  constructor(private svc:Authentication,private formmbuilder:FormBuilder,
                private router:Router) { }

  ngOnInit(): void {

   /* this.userRegistrationForm=this.formmbuilder.group({
      Title: ['', [Validators.required]],
      Author: ['', [Validators.required]],
      Description: ['', [Validators.required]],
      ImageUrl: ['', [Validators.required]],
      Price: ['', [Validators.required]],
      Quantity: ['', [Validators.required]],
  }*/
}
  AddCustomer()
  {
    //console.log(this.Customer);
    this.svc.AddCustomer(this.Customer).subscribe(
      (Response)=>
      {
      console.log(Response);


        this.router.navigate(['/login']);


      });
  }

}
