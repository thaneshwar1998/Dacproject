import { Component, OnInit } from '@angular/core';
import { FormBuilder ,FormGroup,FormControl,Validators} from '@angular/forms';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { Books } from '../Book.module';
import{BooksHubService} from'../books-hub.service';
@Component({
  selector: 'app-insert',
  templateUrl: './insert.component.html',
  styleUrls: ['./insert.component.css']
})
export class InsertComponent implements OnInit
{
  imageUrl:string="/assets/Images/DefaultImage1.jpg";
  fileToUpload:File=null;
  /*dataSaved = false;
  bookForm: any;
  allBooks: Observable<Books[]>;
  BookIdUpdate = null;
  massage = null;  */
  book=new Books();

  insertForm=new FormGroup(
    {
      Title:new FormControl('',[Validators.required]),
      Author:new FormControl('',[Validators.required,Validators.email]),
      Description:new FormControl('',[Validators.required,Validators.maxLength(50)]),
      Price:new FormControl('',[Validators.required]),
      Quantity:new FormControl('',[Validators.required,Validators.minLength(10),Validators.maxLength(12)]),
      Language:new FormControl('',[Validators.required]),
      Category:new FormControl('',[Validators.required]),
      Rating:new FormControl('',[Validators.required]),
      BookCondition:new FormControl('',[Validators.required]),
    }
  )
  constructor(private svc:BooksHubService,private formbuilder:FormBuilder,
              private router:Router) { }

  ngOnInit(): void {
    /*this.bookForm=this.formbuilder.group({
      Title: ['', [Validators.required]],
      Author: ['', [Validators.required]],
      Description: ['', [Validators.required]],
      ImageUrl: ['', [Validators.required]],
      Price: ['', [Validators.required]],
      Quantity: ['', [Validators.required]],
    });*/

  }
  handleFileInput(file:FileList)
  {
    this.fileToUpload=file.item(0);

    var reader=new FileReader();
    reader.onload=(event:any) =>
    {
      this.imageUrl=event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
  }


  insert()
  {
    //console.log(this.book);
    this.svc.insertBook(this.book).subscribe(
      (Response)=>
      {
      console.log(Response);
      this.router.navigate(['/books']);
      });
  }
  /*onFormSubmit() {
    this.dataSaved = false;
    const book = this.bookForm.value;
    this.insertBook(book);
    this.bookForm.reset();
  }

  insertBook(book: Books) {
    if (this.BookIdUpdate == null) {
      this.svc.insertBook(book).subscribe(
        () => {
          this.dataSaved = true;
          this.massage = 'Record saved Successfully';
          //this.loadAllEmployees();
          this.BookIdUpdate = null;
          this.bookForm.reset();
        }
      );
    }
  }*/
}









