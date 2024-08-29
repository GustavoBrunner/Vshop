import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
//use if in a html file
import { CommonModule } from '@angular/common';

import { ProductComponent } from './components/products/product/product.component';
import { CategoryComponent } from './components/categories/category/category.component';
import { ProductService } from './services/products/product.service';
import { CategoryService } from './services/categories/category.service';
import { ReactiveFormsModule } from '@angular/forms';
import { IProductServiceToken } from './services/contracts/IProductService';
import { ICategoryServiceToken } from './services/contracts/ICategoryService';
import { ClientService } from './services/client/client.service';
import { IClientServiceToken } from './services/contracts/IClientService';
import { ClientComponent } from './components/client/client/client.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    CategoryComponent,
    ClientComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    ReactiveFormsModule,
    
  ],
  //configuration of the dependency injection.
  providers: [HttpClientModule, HttpClient,
    { provide: IProductServiceToken, useClass: ProductService },
    { provide: ICategoryServiceToken, useClass: CategoryService },
    { provide: IClientServiceToken, useClass: ClientService }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
