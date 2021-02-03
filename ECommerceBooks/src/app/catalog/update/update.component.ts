import { Component, OnInit } from '@angular/core';
import { FormBuilder ,Validators} from '@angular/forms';
import { Observable } from 'rxjs';
import {ActivatedRoute,Router } from '@angular/router';
import { Books } from '../Book.module';
import{BooksHubService} from'../books-hub.service';
import { BookDetailsComponent } from '../book-details/book-details.component';


@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  id!:any;
  book!:Books;

  constructor(private svc:BooksHubService,private formbuilder:FormBuilder,
    private route: ActivatedRoute,

    private router:Router) { }
   ngOnInit():void{
        this.id = this.route.snapshot.params['id'];
        this.svc.getBookById(this.id).subscribe(data => {
       console.log(data);
       this.book=data;
       })

   }
   getbook(){
     this.router.navigate(['/bookdetails']);
     }

   onSubmit(){
     this.svc.updateBook(this.id,this.book).subscribe(data=>{
       this.getbook();
     }, error=> console.log(error));

   }
}
