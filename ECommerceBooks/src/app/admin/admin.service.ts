import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from './customer.module';
import { Books } from './Book.module';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http:HttpClient) { }

  getAllCustomers():Observable<Customer>
  {
    let dotneturl:string="http://localhost:60312/api/customer";
    return this.http.get<Customer>(dotneturl);
  }
  getAllBooks():Observable<Books>
  {
    let dotneturl:string="http://localhost:60312/api/books";
    return this.http.get<Books>(dotneturl);
  }

  getCustomerById(id: number):Observable<Customer>{
    let url:string="http://localhost:60312/api/customer/"+id;
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<Customer>(url);
  }
  deleteCustomerById(id:number):Observable<any>{
    let url:string="http://localhost:60312/api/customer/"+id;
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.delete<any>(url);
  }

}
