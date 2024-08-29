import { Component, Inject, inject } from '@angular/core';
import { ProductService } from './services/products/product.service';
import { Observable } from 'rxjs';
import { Product } from './models/product';
import { CategoryService } from './services/categories/category.service';
import { IProductService, IProductServiceToken } from './services/contracts/IProductService';
import { ICategoryService, ICategoryServiceToken } from './services/contracts/ICategoryService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  constructor(){}
  title = 'Página Inicial';

  
}
