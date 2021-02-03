import { Books } from './../../admin/Book.module';
import { Component, OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';
import { BooksHubService } from '../books-hub.service';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.css']
})
export class BooksListComponent implements OnInit {



  ID!:any;
  book!:Books;
  data:Books[];

  constructor(private svc:BooksHubService,private router:Router,private route: ActivatedRoute) { }

  ngOnInit():void {

    this.svc.getAllBooks().subscribe(
      (books:any) =>
      {
         this.data=books;
         console.log(this.data);
         //console.log(this.book.ImageUrl)
      },
      error=>
      {
        console.log(error);
      });
  }
  BuyBook(id:any){
    console.log("in buy book");
   /* console.log(id);
    //id = this.route.snapshot.params['ID'];
   // console.log(id);

     this.svc.getBookById(id).subscribe(data => {
       console.log(data);
       this.book=data;
       })*/
    this.router.navigate(['orders/'+id]);
  }

  insideCart(id:any)
  {
   // console.log("book id"+id);
    this.router.navigate(['cart/'+id])
  }

}
