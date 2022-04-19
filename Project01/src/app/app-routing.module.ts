import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { DecorComponent } from './decor/decor.component';
import { CartComponent } from './cart/cart.component';
import { WfhComponent } from './wfh/wfh.component';
import { FurnituresComponent } from './furnitures/furnitures.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { CheckoutComponent } from './checkout/checkout.component';

const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full' },
  {path:'home', component:HomeComponent},
  {path:'decor', component:DecorComponent},
  {path:'cart', component:CartComponent},
  {path:'wfh', component:WfhComponent},
  {path:'furnitures', component:FurnituresComponent},
  {path:'feedback', component:FeedbackComponent},
  {path:'checkout', component:CheckoutComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
