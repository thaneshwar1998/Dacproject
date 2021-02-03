import { Books } from './../admin/Book.module';
import { ActivatedRoute, Router } from '@angular/router';
import { CartServiceService } from './cart-service.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  id!:any;
  book!:Books;
  quantity:number=1;
  constructor( private route: ActivatedRoute,private svc:CartServiceService,private router:Router) { }

  cartarray:any=[];
  total:number=0;
  count:number=0;
  sum(price,quantity)
  {
    console.log(price,quantity)
    return this.total=price*quantity;
  }
  ngOnInit(): void {

    this.id = this.route.snapshot.params['id'];
    console.log(this.id);

     this.svc.getBookById(this.id).subscribe(data => {
       console.log(data);
       //this.orders.OrderName=this.book.Title;
      // this.orders.Price=this.book.Price;
       this.book=data;
       })

  }

  onAdd()
  {
    //alert("inside add")
    //console.log(this.book)
    this.count++;
    sessionStorage['totalval']=this.total;
    sessionStorage.setItem;
    this.cartarray.push(this.book);
    alert(this.cartarray.length())
    this.router.navigate(['']);
  }

}
