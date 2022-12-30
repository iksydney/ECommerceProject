import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  id: string;
  constructor(private shopService: ShopService, private activateRoute: ActivatedRoute, private bcService: BreadcrumbService) {
    bcService.set('ProductDetails',' ');
   }

  ngOnInit(): void {
    this.loadProduct();
  }
  
  //idNum = Number(this.activateRoute.snapshot.paramMap.get(`$id`));
  loadProduct(){
    //this.activateRoute.paramMap.subscribe(param => {this.id = param.get('id'); });
    this.shopService.getProduct(parseInt(this.activateRoute.snapshot.paramMap.get('id'))).subscribe(product => {
      this.product = product;
      this.bcService.set('@productDetails', product.name);
    }, error => {
      console.log(error);
      //console.log(+this.activateRoute.snapshot.paramMap.get(`$id`));
      
    });
  }
}
