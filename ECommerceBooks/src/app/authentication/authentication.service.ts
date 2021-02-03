import { CanActivate ,ActivatedRouteSnapshot,Router,RouterStateSnapshot} from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from './customer.module';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class Authentication  implements CanActivate
{
  baseURL='http://localhost:60312/api/validate';
  constructor(private http:HttpClient,private route:Router) { }

  AddCustomer(data)
  {
        return this.http.post('http://localhost:60312/api/customer',data);
  }

  getCustomer(email: string,password:string):Observable<Customer>{
    //console.log(email,password)
    let url:string="http://localhost:60312/api/customer?"+email+"&"+password;
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<Customer>(url);

  }

  //authentication function
  /*authenticate(UserName:string,Password:string)
  {
    console.log(UserName,Password);
    return this.http.post<any>(this.baseURL,{UserName,Password}).pipe(map(resp=>{
      console.log(`token ${resp}`);
      sessionStorage.setItem("userDtls",UserName+":"+Password);
      sessionStorage.setItem("jwtString",'Bearer' +resp.jwt);
      return resp;
    }));
  }*/
  login(email: string, password: string)
  {
    const body = {
      email: email,
      password: password
    }
    return this.http.post(this.baseURL,body);
    console.log("inside login service");
  }

  canActivate(router:ActivatedRouteSnapshot,state:RouterStateSnapshot)
  {
    if(!sessionStorage['email'])
    {
      console.log(router.url);
      console.log(state.url)
      this.route.navigate(['/login'])
      return false;
    }
  }

  isUserLoggedIn(): boolean {
    let flag = true;
    if (sessionStorage.getItem("email") === null)
      flag = false;
    console.log(`flag=${flag}`);
    return flag;
  }
  logout(): void {
    sessionStorage.removeItem("email");
    sessionStorage.removeItem("email");
  }

}
/*
export class AuthServiceService {
  baseURL = 'http://localhost:8080/authenticate';
  constructor(private http: HttpClient) { }
  //add member function for authentication
  authenticate(userName: string, password: string) {
     return this.http.post<any>(this.baseURL,{userName,password}).pipe(map(resp => {
      console.log(`token ${resp}`);
      sessionStorage.setItem("userDtls", userName + ":" + password);
      sessionStorage.setItem("jwtString", 'Bearer ' +resp.jwt);
      return resp;
    }));
  }
  isUserLoggedIn(): boolean {
    let flag = true;
    if (sessionStorage.getItem("userDtls") === null)
      flag = false;
    console.log(`flag=${flag}`);
    return flag;
  }
  logout(): void {
    sessionStorage.removeItem("userDtls");
    sessionStorage.removeItem("jwtString");
  }
}*/
