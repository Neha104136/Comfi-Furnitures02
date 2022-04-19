import { Component, OnInit } from '@angular/core';

import { wfhService } from 'src/services/wfh.service';
import { wfh } from 'src/services/wfh';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-wfh',
  templateUrl: './wfh.component.html',
  styleUrls: ['./wfh.component.css']
})
export class WfhComponent implements OnInit {

  wfh!: wfh[];
  constructor( private auth: AuthService, private wfhService: wfhService ) { }

  ngOnInit(): void {

    this.wfhService.getAllwfh().subscribe((data : wfh[]) => {
      this.wfh = data;
      //console.log(this.wfh)

    });

  }

  itemsCart:any = [];
  addCart(category: any){
    let cartDataNull = localStorage.getItem('localCart');

    if(cartDataNull == null){
      let storeDataGet:any = [];
      storeDataGet.push(category);
      localStorage.setItem('localCart', JSON.stringify(storeDataGet));
    }
    else{
      var id = category.prodid;
      let index:number = -1;
      this.itemsCart = JSON.parse(localStorage.getItem('localCart') || '{}');

      for(let i=0; i<this.itemsCart.length; i++){
        if(parseInt(id) === parseInt(this.itemsCart[i].prodid)){
          //this.itemsCart[i].prodquantity = category.prodquantity;
          if(this.itemsCart[i].prodquantity != 5){
            this.itemsCart[i].prodquantity +=1;
          }
          index = 1;
          break;
        }
      }

      if(index == -1){
        this.itemsCart.push(category);
        localStorage.setItem('localCart', JSON.stringify(this.itemsCart));
      }
      else{
        localStorage.setItem('localCart', JSON.stringify(this.itemsCart));
      }
    }
    this.cartNumberFunc();
    alert('Your product has been added to the cart!');
  }

  cartNumber:number = 0;
  cartNumberFunc(){
    var cartValue = JSON.parse(localStorage.getItem('localcart') || '{}');
    this.cartNumber = cartValue.length;
    this.auth.cartSubject.next(this.cartNumber);
  }


}
