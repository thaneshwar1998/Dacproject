import { CartComponent } from './../cart/cart.component';
import { SearchComponent } from './../search/search.component';
import { ShipmentsComponent } from './../shipments/shipments.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {Routes,RouterModule} from '@angular/router';
import { CatalogModule } from '../catalog/catalog.module';
import { StandardModule } from '../standard/standard.module';
import { ContainerComponent } from './container/container.component';
import { HomeComponent } from '../standard/home/home.component';
import { AboutusComponent } from '../standard/aboutus/aboutus.component';
import { ContactusComponent } from '../standard/contactus/contactus.component';
import { ServicesComponent } from '../standard/services/services.component';
import{BooksListComponent} from '../catalog/books-list/books-list.component';
import { LoginComponent } from '../authentication/login/login.component';
import { RegisterComponent } from '../authentication/register/register.component';
import {InsertComponent} from '../catalog/insert/insert.component';
import { AdminComponent } from '../admin/admin.component';
import { UpdateComponent } from '../catalog/update/update.component';
import { BookDetailsComponent } from '../catalog/book-details/book-details.component';
import { OrdersComponent } from '../orders/orders.component';
import { PaymentsComponent } from '../payments/payments.component';
const routes:Routes=
[
  {path:'',redirectTo:'books',pathMatch:'full'},
  {path:'home',component:HomeComponent},
  {path:'aboutus',component:AboutusComponent},
  {path:'contactus',component:ContactusComponent},
  {path:'service',component:ServicesComponent},
  {path:'books',component:BooksListComponent},
  {path:'login',component:LoginComponent},
  {path:'register',component:RegisterComponent},
  {path:'insert',component:InsertComponent},
  {path:'admin',component:AdminComponent},
  {path:'update/:id',component:UpdateComponent},
  {path:'bookdetails',component:BookDetailsComponent},
  {path:'orders/:id',component:OrdersComponent},
  {path:'payments',component:PaymentsComponent},
  {path:'shipments',component:ShipmentsComponent},
  {path:'search',component:SearchComponent},
  {path:'cart/:id',component:CartComponent}


];


@NgModule({
  declarations: [ContainerComponent],
  imports: [
    CommonModule,
    CatalogModule,
    StandardModule,
    RouterModule.forRoot(routes)
  ],
  exports:[
    ContainerComponent
  ]
})
export class SPAModule { }
