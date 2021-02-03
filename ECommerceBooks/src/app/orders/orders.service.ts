import { Orders } from './order.module';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Books } from '../catalog/Book.module';

@Injectable({
  providedIn: 'root'
})
export class OrdersService
{

  constructor(private http:HttpClient) { }


  getBookById(id: number):Observable<Books>{
    console.log(id);
    let url:string="http://localhost:60312/api/books/"+id;
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<Books>(url);
  }

  insertOrder(data)
  {
    //let url:string="http://localhost:55002/api/books";
    return this.http.post("http://localhost:60312/api/orders",data);
  }
}
