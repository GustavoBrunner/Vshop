import { InjectionToken } from "@angular/core";
import { Observable } from "rxjs";
import { Category } from "../../models/category";

export const ICategoryServiceToken = new InjectionToken<ICategoryService>('ICategoryServiceToken');

export interface ICategoryService{
    createCategory(category: Category): Observable<Category>;
    getById(id: string): Observable<Category>;
    getAll(): Observable<Category[]>;
    updateCategory(category: Category): Observable<Category>;
    deleteCategory(id: string): Observable<boolean>;
}