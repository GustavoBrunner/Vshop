import { InjectionToken } from "@angular/core";
import { Observable } from "rxjs";
import { Product } from "../../models/product";

export const IProductServiceToken = new InjectionToken<IProductService>('IProductServiceToken')

export interface IProductService{
    createProduct(product: Product): Observable<Product>;
    getAll(): Observable<Product[]>;
    getById(id: string): Observable<Product>;
    updateProduct(product: Product): Observable<Product>;
    deleteProduct(id:string): Observable<boolean>;
}