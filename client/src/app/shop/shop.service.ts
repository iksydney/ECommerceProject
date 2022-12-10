import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { IBrands } from '../shared/models/brands';
import { IProductPagination } from '../shared/models/pagination';
import { IProductTypes } from '../shared/models/productTypes';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
baseUrl = 'https://localhost:7274/api/';

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams){
    let params = new HttpParams();

    if(shopParams.brandId !== 0)
    {
      params = params.append('brandId', shopParams.brandId.toString());
    }
    if(shopParams.typeId !== 0)
    {
      params = params.append('typeId', shopParams.typeId.toString());
    }
    if(shopParams.search)
    {
      params = params.append('search', shopParams.search);
    }
      params = params.append('sort', shopParams.sort);
      params = params.append('pageIndex', shopParams.pageNumber.toString());
      params = params.append('pageSize', shopParams.pageSize.toString());
    

    //return this.http.get<IProductPagination>(this.baseUrl + 'Products/GetAllProducts?pageSize=50');
    return this.http.get<IProductPagination>(this.baseUrl + 'Products/GetAllProducts', {observe: 'response', params})
    .pipe(
      map(response => {
        return response.body;
      })
    );
  }

  getTypes(){
    return this.http.get<IProductTypes[]>(this.baseUrl + 'ProductTypes/GetAllProductTypes');
  }

  getBrands(){
    return this.http.get<IBrands[]>(this.baseUrl + 'ProductBrand/GetAllProductBrand');
  }
}
