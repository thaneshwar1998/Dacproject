import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { ContactusComponent } from './contactus/contactus.component';
import { ServicesComponent } from './services/services.component';



@NgModule({
  declarations: [
                  HomeComponent, 
                  AboutusComponent, 
                  ContactusComponent, 
                  ServicesComponent
                ],
  imports: [
    CommonModule,

  ],
  exports:[
                HomeComponent, 
                AboutusComponent, 
                ContactusComponent, 
                ServicesComponent
  ]
})
export class StandardModule { }
