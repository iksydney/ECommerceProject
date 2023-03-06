import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { BasketService } from './basket/basket.service';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'client';
  
  constructor(private basketService: BasketService, private accountService: AccountService, private spinner: NgxSpinnerService){}

  ngOnInit(): void 
  {
    this.loadBasket();
    this.loadCurrentUser();
    this.spinner.show();
  }

  loadCurrentUser()
  {
    const token = localStorage.getItem('token');
    if(token)
    {
      this.accountService.loadCurrentUser(token).subscribe(() => {
        console.log('Loaded current User');
      }, error => {
        console.log(error);
        
      })
    }
  }
  loadBasket()
  {
    const basketId = localStorage.getItem('basket_id');
    if(basketId)
    {
      this.basketService.getBasket(basketId).subscribe(() => {
        console.log('basket initialised');
      }, error => {
        console.error(error);
      });
    }
  }
}
