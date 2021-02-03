import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.css']
})
export class ContainerComponent implements OnInit {


  email=sessionStorage.getItem('email');
  count:number=0;

  constructor(private router:Router) { }

  ngOnInit(): void {
    sessionStorage['count']=this.count;
    
  }
  endSession()
  {
    sessionStorage.removeItem('email');
    sessionStorage.clear();
    alert("Logged Out Successfully ")

    this.router.navigate(['/login'])
  }

  valid()
  {
    if(this.email.match("swapnil.padwekar95@gmail.com"))
    {
      alert("valid Admin login")
    }
    else
    {
      alert("invalid Admin Login")
      this.router.navigate(['/login'])
    }
  }
}
