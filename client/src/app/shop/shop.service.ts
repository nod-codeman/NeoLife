import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/Models/brands';
import { IPagination } from '../shared/Models/pagination';
import { IType } from '../shared/Models/productType';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient  ) { }

  // method to return products from the api
  getProducts(brandId?: number, typeId?: number, sort?: string){
    let params = new HttpParams();

    if (brandId) {
      params = params.append('brandId', brandId.toString());
    }

    if (typeId) {
      params = params.append('brandId', typeId.toString());
    }

    if (sort) {
      params = params.append('sort', sort);
    }
    return this.http.get<IPagination>(this.baseUrl + 'products', {observe: 'response', params})
    .pipe( // use pipe to extract the http object
      map(response => {
        return response.body;
      })
    )
  }

  getBrands(){
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getTypes(){
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }
}
