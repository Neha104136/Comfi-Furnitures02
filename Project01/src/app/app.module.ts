import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DecorComponent } from './decor/decor.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { CartComponent } from './cart/cart.component';
import { HeaderComponent } from './header/header.component';
import { WfhComponent } from './wfh/wfh.component';
import { FurnituresComponent } from './furnitures/furnitures.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { AuthService } from 'src/services/auth.service';
import { FeedbackComponent } from './feedback/feedback.component';

@NgModule({
  declarations: [
    AppComponent,
    DecorComponent,
    HomeComponent,
    FooterComponent,
    CartComponent,
    HeaderComponent,
    WfhComponent,
    FurnituresComponent,
    FeedbackComponent,
    CheckoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
