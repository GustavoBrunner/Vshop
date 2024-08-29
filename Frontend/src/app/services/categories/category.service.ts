import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../../models/category';
import { ICategoryService } from '../contracts/ICategoryService';

const header = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CategoryService implements ICategoryService {
  constructor(private client: HttpClient) { }
  url = 'https://localhost:7281/api/category/';

  getAll(): Observable<Category[]> {
    return this.client.get<Category[]>(this.url);
  }

  getById(id: string): Observable<Category> {
    const newUrl = this.url + id;
    return this.client.get<Category>(newUrl);
  }

  createCategory(category: Category ):Observable<Category>{
    return this.client.post<Category>(this.url, category, header);
  } 

  updateCategory(category: Category): Observable<Category>{
    const newUrl = this.url+category.categoryId;
    return this.client.put<Category>(newUrl, category, header);
  }

  deleteCategory(id: string): Observable<boolean>{
    const newUrl = this.url+id;
    return this.client.delete<boolean>(newUrl, header);
  }

}
