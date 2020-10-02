import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/Models/brands';
import { IPagination } from '../shared/Models/pagination';
import { IType } from '../shared/Models/productType';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient  ) { }

  // method to return products from the api
  getProducts(){
    return this.http.get<IPagination>(this.baseUrl + 'products?pageSize=50');
  }

  getBrands(){
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getTypes(){
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }
}
