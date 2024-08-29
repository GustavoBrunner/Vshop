import { Component, Inject, OnInit, Type } from '@angular/core';
import { IProductService, IProductServiceToken } from '../../../services/contracts/IProductService';
import { Category } from '../../../models/category';
import { Product } from '../../../models/product';
import { FormControl, FormGroup } from '@angular/forms';
import { ICategoryService, ICategoryServiceToken } from '../../../services/contracts/ICategoryService';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit {


  constructor(@Inject(IProductServiceToken) private productService: IProductService,
        @Inject(ICategoryServiceToken) private categoryService: ICategoryService){}
  
  teste = "";
  //table attributes
  isShowTable: boolean = true;
  products: Product[] = [];

  //form attributes
  isShowForm: boolean = false;
  productForm: any;
  categories: Category[] = []
  formTitle: string = "";

  ngOnInit(): void {
    // let names: string = "";
    // const products = this.productService.getAll()
    //   .subscribe( result => {
    //     result.forEach(product => {
    //       names += product.name;
    //     });
    //     alert(names);
    //   });
    
    this.getProducts();
  }
  showForm(product: any = null): void {
    this.isShowTable = false;
    this.isShowForm = true;
    this.formTitle = product != null 
        ? `Alteração de produto: ${(product as Product).name} ` 
        : "Cadastro de produto!";

    this.categoryService.getAll().subscribe( result => {
      this.categories = result;
    })
    
    this.productForm = new FormGroup({
      productId: new FormControl(product != null ? (product as Product).productId : null),
      name: new FormControl(product != null ? (product as Product).name : null),
      description: new FormControl(product != null ? (product as Product).description : null),
      price: new FormControl(product != null ? (product as Product).price : null),
      stock: new FormControl(product != null ? (product as Product).stock : null),
      categoryId: new FormControl(product != null ? (product as Product).categoryId : null)
    })
    
  }



  

  showTable(): void {
    this.getProducts();
    this.isShowForm = false;
    this.isShowTable = true;
  }


  
  sendForm(): void{
    let productMapped = this.productMap((this.productForm.value as Product))
    if((this.productForm.value as Product).productId != null){
      this.productService.updateProduct(this.productForm.value as Product).subscribe();
      
      this.showTable();
    }
    else{
      this.productService.createProduct(productMapped).subscribe();
      this.showTable();
    }
    
  }

  delete(id: string): void {
    this.productService.deleteProduct(id).subscribe();
  }

  getProducts(): void{
    this.productService.getAll().subscribe( result =>{
      this.products = result;
    });
  }


  productMap(from: Product): Product{
    let to: Product = new Product();
    to.categoryId = from.categoryId;
    to.categoryName = from.categoryName;
    to.description = from.description;
    to.name = from.name;
    to.price = from.price;
    to.productImage = from.productImage;
    to.stock = from.stock;

    return to;
  }

}
