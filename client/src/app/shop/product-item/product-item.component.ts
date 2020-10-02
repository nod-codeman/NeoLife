import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/Models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  // @Input used to bind between parent and child components
  @Input() product: IProduct;

  constructor() { }

  ngOnInit(): void {
  }

}
