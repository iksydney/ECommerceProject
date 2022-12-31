import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BasketComponent } from './basket/basket.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { SectionHeaderComponent } from './core/section-header/section-header.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { HomeComponent } from './home/home.component';
import { OrderTotalsComponent } from './shared/components/order-totals/order-totals.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { ShopComponent } from './shop/shop.component';

const routes: Routes = 
[
  //The data property is for the bredcrumb to read the navigation property.
  {path:'', component:HomeComponent, data: {breadcrumb:'Home'}},
  {path: 'test-error', component:TestErrorComponent, data: {breadcrumb:'Test Error'}},
  {path: 'not-found', component:NotFoundComponent, data: {breadcrumb:'Not Found'}},
  {path: 'server-error', component:ServerErrorComponent, data: {breadcrumb:'Server Error'}},
  {path: 'header', component:SectionHeaderComponent},
  {path: 'totals', component:OrderTotalsComponent},
  {path:'shop', loadChildren: () => import('./shop/shop.module').then(x => x.ShopModule), data: {breadcrumb:'Shop'}},
  {path:'basket', loadChildren: () => import('./basket/basket.module').then(x => x.BasketModule), data: {breadcrumb:'Basket'}},
  {path:'checkout', loadChildren: () => import('./checkout/checkout.module').then(x => x.CheckoutModule), data: {breadcrumb:'Checkout'}},
  {path:'**', redirectTo:'not-found',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
