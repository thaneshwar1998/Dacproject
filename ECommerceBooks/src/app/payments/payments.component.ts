import { Payment } from './payment.module';
import { PaymentsService } from './payments.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup ,FormControl,Validators} from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.css']
})
export class PaymentsComponent implements OnInit {

   ProductName = sessionStorage.TotalPrice;
  toggleOn:boolean=true;

  payment=new Payment();

  form=new FormGroup(
    {
      TransactionID:new FormControl('',Validators.required),
      Name:new FormControl('',Validators.required),
      CardNumber:new FormControl('',Validators.required),
      CVV:new FormControl('',Validators.required),
      Amount:new FormControl('',Validators.required),
      PaymentDate:new FormControl('',Validators.required),

    })

  constructor(private router:Router, private route: ActivatedRoute,private svc:PaymentsService) { }

  ngOnInit(): void {
   // this.payment.Amount=sessionStorage.getItem["TotalPrice"]

  }
  payNow()
  {
    //this.payment.Amount=sessionStorage.getItem["TotalPrice"]
    this.svc.insertPayment(this.payment).subscribe(
      (Response)=>
      {
        console.log(Response);
        this.router.navigate(['/shipments'])
      });

  }

  shippingForm()
  {
    this.router.navigate(['/shipments'])
  }

}
