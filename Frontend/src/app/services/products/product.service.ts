import {  HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../../models/product';
import { IProductService } from '../contracts/IProductService';

const header = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ProductService implements IProductService {
  constructor(private client: HttpClient)  { }

  url = 'https://localhost:7281/api/product/';

  getAll(): Observable<Product[]>{
    return this.client.get<Product[]>(this.url);
  }
  getById(id: string): Observable<Product>{
    const newUrl = this.url + id;
    return this.client.get<Product>(newUrl);
  }
  deleteProduct(id: string): Observable<boolean> {
    const newUrl = this.url + id;
    return this.client.delete<boolean>(newUrl, header);
  }
  createProduct(product: Product): Observable<Product>{
    console.debug(product);
    return this.client.post<any>(this.url,product, header);
  }
  updateProduct(product: Product): Observable<Product>{
    const newUrl = this.url + product.productId;
    
    return this.client.put<any>(newUrl, product, header);
  }
}
