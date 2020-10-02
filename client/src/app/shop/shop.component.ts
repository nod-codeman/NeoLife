import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/Models/brands';
import { IProduct } from '../shared/Models/product';
import { IType } from '../shared/Models/productType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: IProduct[];
  brands: IBrand[];
  types: IType[];

  constructor(private shopService: ShopService) { }

  ngOnInit() { // call methods
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  // consume the shop service
  getProducts(){
    this.shopService.getProducts().subscribe(response => {
      this.products = response.data;
    }, error =>{
      console.log(error);
    });
  }

  getBrands(){
    this.shopService.getBrands().subscribe(response => {
      this.brands = response;
    }, error => {
      console.log(error);
    });
  }

  getTypes(){
    this.shopService.getTypes().subscribe(response => {
      this.types = response;
    }, error => {
      console.log(error);
    });
  }

}
