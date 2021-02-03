import { ShipmentService } from './shipment.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Shipment } from './shipment.module';

@Component({
  selector: 'app-shipments',
  templateUrl: './shipments.component.html',
  styleUrls: ['./shipments.component.css']
})
export class ShipmentsComponent implements OnInit {

  shipment=new Shipment()
  constructor(private router:Router, private route: ActivatedRoute,private svc:ShipmentService) { }

  ngOnInit(): void {
  }

  showReceipt()
  {
    this.svc.insertShipment(this.shipment).subscribe(
      (Response)=>
      {
        console.log(Response);

      });

    alert("Order Placed successfully")
    sessionStorage.removeItem['email'];
    this.router.navigate([''])
  }
}
