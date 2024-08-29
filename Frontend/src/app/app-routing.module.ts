import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './components/products/product/product.component';
import { CategoryComponent } from './components/categories/category/category.component';
import { ClientComponent } from './components/client/client/client.component';

const routes: Routes = [
  {path: 'product', component: ProductComponent},
  {path: 'category', component: CategoryComponent},
  {path: 'client', component: ClientComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
