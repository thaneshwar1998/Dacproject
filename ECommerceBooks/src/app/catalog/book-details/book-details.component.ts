import { Component, OnInit } from '@angular/core';
import { FormBuilder ,Validators} from '@angular/forms';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { Books } from '../Book.module';
import{BooksHubService} from'../books-hub.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {


  public book:Books;

  constructor(private svc:BooksHubService,private formbuilder:FormBuilder,


    private router:Router) { }

  ngOnInit():void{
    this.getbooks();

  }

 getbooks(){
   this.svc.getAllBooks().subscribe(data => {
     console.log(data);
     this.book=data;
    // alert("updated succesfully!!!");
     })

   }
   updateBook(id: number){
     this.router.navigate(['update', id]);

   }
   deleteBook(id:number){
     this.svc.deleteBookById(id).subscribe(data=>{
       console.log(data);
       this.getbooks();
       alert("deleted succesfully!!!");
   })

   }
 }
