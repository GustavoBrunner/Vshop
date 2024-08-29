import { Component, Inject, OnInit } from '@angular/core';
import { ICategoryService, ICategoryServiceToken } from '../../../services/contracts/ICategoryService';
import { Category } from '../../../models/category';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent implements OnInit {


  constructor(@Inject(ICategoryServiceToken) private categoryService: ICategoryService){}
  
  ngOnInit(): void {
    this.showTable();
  }

  //table attributes
  isShowTable: any;
  categories: Category[] = [];

  //form attributes
  isShowFform: any;
  categoryForm: any;
  
  showTable(): void {
    this.isShowTable = true;
    this.isShowFform = false;
    this.getCategories(); 
  }
  
  showForm(category: any = null): void {
    this.isShowFform = true;
    this.isShowTable = false;

    this.categoryForm = new FormGroup({
      categoryName: new FormControl(category != null? (category as Category).categoryName : null),
      products: new FormControl(category != null && (category as Category).products.length > 0 
          ? "See products"
          : "No products")
    })
  }

  getCategories(): void{
    this.categoryService.getAll().subscribe( result => {
      this.categories = result;
    });
  }
  delete(id: string): void {
    this.categoryService.deleteCategory(id).subscribe( result => {
      if(result)
        alert("Category deleted");
      else
        alert("Not possible to delete category!");
    })
  }
  sendForm(){
    let category = this.categoryForm.value as Category;
    if(category.categoryId != null){
      //UPDATE entity
      this.categoryService.updateCategory(category).subscribe();
    }
    else{
      //CREATE entity
      this.categoryService.createCategory(category).subscribe();
    }
  }
  newProduct(categoryId: string): void {
    
  }


}
