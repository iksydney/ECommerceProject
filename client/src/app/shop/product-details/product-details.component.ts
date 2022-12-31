import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from 'src/app/basket/basket.service';
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
  quantity = 1;
  id: string;
  constructor(private shopService: ShopService, 
    private activateRoute: ActivatedRoute, 
    private bcService: BreadcrumbService, 
    private basketService: BasketService) {
    bcService.set('ProductDetails',' ');
   }

  ngOnInit(): void {
    this.loadProduct();
  }

  adItemToBasket()
  {
    this.basketService.addItemToBasket(this.product, this.quantity);
  }

  incrementQuantity()
  {
    this.quantity++;
  }
  
  decrementQuantity()
  {
    if(this.quantity > 0){
      this.quantity--;
    }
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
