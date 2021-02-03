import { FormBuilder } from '@angular/forms';
import { Books } from './../admin/Book.module';
import { SearchServiceService } from './search-service.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  /*constructor(public fb: FormBuilder) { }

  oppoSuitsForm = this.fb.group({
    name: ['']
  })*/

  data:Books[];
  data1=new Books();
  flag1:boolean=true;
  search:any;
  category1:any="General"
  category: any = ['Fiction', 'Non-Fiction', 'General', 'Autobiography']
  constructor(private svc:SearchServiceService,private cat:FormBuilder) { }

  optioncat=this.cat.group(
    {
      name:['']
    }
  )
  ngOnInit(): void {

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

  OnSearch(s)
  {
    this.flag1=true;
    console.log(s);
    this.svc.getBookByCategory(s).subscribe(
      (category:any) =>
      {
        this.data1=category;
        console.log(this.data1)
      }

    )
  }

}
