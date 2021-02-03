import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PaymentsService {

  constructor(private http:HttpClient) { }


  insertPayment(data)
  {
    //let url:string="http://localhost:55002/api/books";
    return this.http.post("http://localhost:60312/api/payments",data);
  }
}
