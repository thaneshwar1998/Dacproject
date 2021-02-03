import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Books } from './Book.module';

@Injectable({
  providedIn: 'root'
})
export class BooksHubService {

  constructor(private http:HttpClient) { }

  getAllBooks():Observable<Books>
  {
    let dotneturl:string="http://localhost:60312/api/books";
    return this.http.get<Books>(dotneturl);
  }


  /*insertBook(book: Books): Observable<Books> {
    let url:string="http://localhost:55002/api/books";
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<Books>(url ,book, httpOptions);
  }  */

  insertBook(data)
  {
    //let url:string="http://localhost:55002/api/books";
    return this.http.post("http://localhost:60312/api/books",data);
  }
  updateBook(id:number,book: Books):Observable<Books>
  {
    let url:string="http://localhost:60312/api/books/"+id;
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.put<Books>(url,book, httpOptions);
  }
  getBookById(id: number):Observable<Books>{
    let url:string="http://localhost:60312/api/books/"+id;
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<Books>(url);
  }
  deleteBookById(id:number):Observable<any>{
    let url:string="http://localhost:60312/api/books/"+id;
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.delete<any>(url);
  }

}

/*getAllBooks(): any
{

// fetch data from external REST API
// http request code for REST API
//
return this.books;
}

getBookById(id:number):any
{
return this.books[id];
}

insert(newBook:any):boolean
{
let status=false;


//inserting new product into aray.
return status;
}


update(newBook:any){
//inserting new product into aray.

let status=false;


//updating existing product into aray.
return status;
}


delete(id:any){
//inserting new product into aray.

let status=false;
//deletion new product into aray.
return status;
}*/

