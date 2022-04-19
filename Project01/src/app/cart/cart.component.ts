import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  constructor(private auth: AuthService, private router: Router) {
    this.auth.totalSubject.subscribe(data=>{
      this.total = data;
    });
  }

  ngOnInit(): void {
    this.CartDetails();
    this.loadCart();
  }

  getCartDetails:any=[];
  CartDetails(){
    if(localStorage.getItem('localCart')){
      this.getCartDetails = JSON.parse(localStorage.getItem('localCart') || '{}');
      console.log(this.getCartDetails);
    }
  }

  total:number = 0;
  loadCart(){
    if(localStorage.getItem('localCart')){
      this.getCartDetails = JSON.parse(localStorage.getItem('localCart') || '{}');
      this.total = this.getCartDetails.reduce(function(acc: any, val: any){
        return acc + (val.prodprice * val.prodquantity);
      },0);
    }
    this.auth.totalSubject.next(this.total);
  }

  removeall(){
    localStorage.removeItem('localCart');
    this.getCartDetails = [];
    this.total = 0;
    this.cartNumber = 0;
    this.auth.cartSubject.next(this.cartNumber);
  }

  singleDelete(getCartDetail: any){
    if(localStorage.getItem('localCart')){
      this.getCartDetails = JSON.parse(localStorage.getItem('localCart') || '{}');

      for( let i=0; i<this.getCartDetails.length; i++){
        if(this.getCartDetails[i].prodid === getCartDetail){
          this.getCartDetails.splice(i, 1);
          localStorage.setItem('localCart', JSON.stringify(this.getCartDetails));
          this.loadCart();
          this.cartNumberFunc();
        }
      }
    }
  }

  cartNumber:number = 0;
  cartNumberFunc(){
    var cartValue = JSON.parse(localStorage.getItem('localcart') || '{}');
    this.cartNumber = cartValue.length;
    this.auth.cartSubject.next(this.cartNumber);
  }

  incQnt(prodId: any, qnt: any){
    for(let i=0; i<this.getCartDetails.length; i++){
      if(this.getCartDetails[i].prodid === prodId){
        if(qnt != 5)
          this.getCartDetails[i].prodquantity = parseInt(qnt) + 1;
      }
    }
    localStorage.setItem('localCart', JSON.stringify(this.getCartDetails));
    this.loadCart();
  }

  decQnt(prodId: any, qnt: any){
    for(let i=0; i<this.getCartDetails.length; i++){
      if(this.getCartDetails[i].prodid === prodId){
        if(qnt != 1)
          this.getCartDetails[i].prodquantity = parseInt(qnt) - 1;
      }
    }
    localStorage.setItem('localCart', JSON.stringify(this.getCartDetails));
    this.loadCart();
  }

  checkoutbtn(){
    this.router.navigateByUrl('/checkout');
  }
}
