import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProductPagination } from './models/pagination';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'client';
  products: IProduct[];
  
  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.http.get('https://localhost:7274/api/Products/GetAllProducts?pageSize=50').subscribe((response: IProductPagination) =>{
      this.products = response.data;      
    }, error => {
      console.log(error);
    });
  }
}
