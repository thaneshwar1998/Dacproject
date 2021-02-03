import { Books } from './../admin/Book.module';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CartServiceService {

  constructor(private http:HttpClient) { }


  getBookById(id: number):Observable<Books>
  {
    let url:string="http://localhost:60312/api/books/"+id;
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<Books>(url);
  }
}
