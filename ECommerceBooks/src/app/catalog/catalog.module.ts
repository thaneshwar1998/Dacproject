import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { BookDetailsComponent } from './book-details/book-details.component';
import { BooksListComponent } from './books-list/books-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthenticationModule } from '../authentication/authentication.module';
import { LoginComponent } from '../authentication/login/login.component';
import { RegisterComponent } from '../authentication/register/register.component';
import { InsertComponent } from './insert/insert.component';
import { UpdateComponent } from './update/update.component';



@NgModule({
  declarations: [
                  BookDetailsComponent,
                  BooksListComponent,
                  InsertComponent,
                  UpdateComponent
                ],
  imports: [
            CommonModule,
            FormsModule,
            AuthenticationModule,
            HttpClientModule,
            ReactiveFormsModule
            ],
  exports:[
            BookDetailsComponent,
            BooksListComponent,
            InsertComponent,
            UpdateComponent
          ]
})
export class CatalogModule { }
