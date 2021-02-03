import { Component, OnInit } from '@angular/core';
import { Books } from '../catalog/Book.module';
import { Router } from '@angular/router';
import{BooksHubService} from'../catalog/books-hub.service';
import { AdminService } from './admin.service';
import { Customer } from './customer.module';
import { FormBuilder ,Validators} from '@angular/forms';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  flag:boolean=true;
  flag1:boolean=true;

  columns=["ID","Name","Email","Password","Address","ContactNumber","Role","Action"];
  index=["ID","Name","Email","Password","Address","ContactNumber","Role"]

    book=["ID","Title","Author","Price","Quantity","Rating","Condition","Action"];
    bookindex=["ID","Title","Author","Price","Quantity","Rating","Condition"]


  data:Customer[]=[];
  data1:Books[]=[];

  constructor(private svc:AdminService,private formbuilder:FormBuilder,private router:Router) { }

  ngOnInit(): void{
    
  }
  toggleCollapse1()
  {
    this.flag=!this.flag;
    this.getAllCustomers();
  }
  toggleCollapse2()
  {
    this.flag1=!this.flag1;
    this.getAllBooks();
  }
  getAllCustomers()
  {
    this.svc.getAllCustomers().subscribe(
      (customer:any) =>
      {
         this.data=customer;

         //console.log(this.data);
      },
      error=>
      {
        console.log(error);
      });
  }

  getAllBooks()
  {
    this.svc.getAllBooks().subscribe(
      (customer:any) =>
      {
         this.data=customer;
         console.log(this.data);
      },
      error=>
      {
        console.log(error);
      });

  }



}
