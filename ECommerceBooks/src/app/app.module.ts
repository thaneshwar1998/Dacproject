import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {MatInputModule} from'@angular/material/input';
import {MatTabsModule} from'@angular/material/tabs';
import {MatSidenavModule} from'@angular/material/sidenav';
import {HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { CatalogModule } from './catalog/catalog.module';
import {BooksHubService} from './catalog/books-hub.service';
import {AuthenticationModule} from './authentication/authentication.module';
import { SPAModule } from './spa/spa.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminComponent } from './admin/admin.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UpdateComponent } from './catalog/update/update.component';
import { OrdersComponent } from './orders/orders.component';
import { PaymentsComponent } from './payments/payments.component';
import { ShipmentsComponent } from './shipments/shipments.component';
import { SearchComponent } from './search/search.component';
import { CartComponent } from './cart/cart.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    OrdersComponent,
    PaymentsComponent,
    ShipmentsComponent,
    SearchComponent,
    CartComponent,
    
  ],
  imports: [
    BrowserModule,
    CatalogModule,
    ReactiveFormsModule,
    FormsModule,
    AuthenticationModule,
    HttpClientModule,
    SPAModule,
    MatInputModule,
    MatTabsModule,
    MatSidenavModule,
    BrowserAnimationsModule

  ],
  exports:[
    MatTabsModule,
    MatSidenavModule
  ],
  providers: [BooksHubService],
  bootstrap: [AppComponent]
})
export class AppModule { }
