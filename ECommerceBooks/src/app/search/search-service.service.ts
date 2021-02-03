import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Books } from './../admin/Book.module';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SearchServiceService {

  constructor(private http:HttpClient) { }

  getAllBooks():Observable<Books>
  {
    let dotneturl:string="http://localhost:60312/api/books";
    return this.http.get<Books>(dotneturl);
  }

  getBookByCategory(category: any):Observable<Books>{
    let url:string="http://localhost:60312/api/search?category="+category;
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<Books>(url);
  }
}
