import { title } from 'process';
import { OrdersService } from './orders.service';
import { Books } from './../admin/Book.module';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';
import { Orders } from './order.module';
import { Component, OnInit } from '@angular/core';
import { DatePipe, formatDate } from '@angular/common';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit
{

  orders=new Orders()

  today=new Date()
  TodayDate()
  {
    this.orders.OrderDate=this.today;
    console.log(this.orders.OrderDate);
    //this.jstoday = formatDate(this.today, 'dd-MM-yyyy hh:mm:ss a', 'en-US', '+0530');
  }

  calculate(price,quantity)
  {
    //console.log(price,quantity);
    this.orders.TotalPrice=price*quantity;
  }
  //data:any=Orders;
  totalprice=sessionStorage.getItem['TotalPrice'];
  id!:any;
  book!:Books;
  data:Books[];
  //newBook=new Books();
  form=new FormGroup(
    {
      OrderID:new FormControl('',Validators.required),
      Title:new FormControl('',Validators.required),
      Price:new FormControl('',Validators.required),
      TotalPrice:new FormControl('',Validators.required),
      Quantity:new FormControl('',Validators.required),
      OrderDate:new FormControl('',Validators.required),

    }
  )


  constructor(private router:Router, private route: ActivatedRoute,private svc:OrdersService) { }

  ngOnInit(): void
  {

    this.id = this.route.snapshot.params['id'];
    console.log(this.id);

     this.svc.getBookById(this.id).subscribe(data => {
       console.log(data);
       //this.orders.OrderName=this.book.Title;
      // this.orders.Price=this.book.Price;
       this.book=data;
       })


  }


  MakePayemt()
  {
    console.log(this.orders,this.book)
    this.svc.insertOrder(this.orders).subscribe(
      (Response)=>
      {
        console.log(Response);
        sessionStorage['TotalPrice']=this.orders.TotalPrice
        this.router.navigate(['/payments'])
      });
  }





}



