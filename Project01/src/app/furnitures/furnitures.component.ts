import { Component, Inject, OnInit } from '@angular/core';
import { furnituresService } from '../../services/furnitures.service'
import { furnitures } from '../../services/furnitures';
import { AuthService } from '../../services/auth.service';

@Inject(furnituresService)

@Component({
  selector: 'app-furnitures',
  templateUrl: './furnitures.component.html',
  styleUrls: ['./furnitures.component.css']
})

export class FurnituresComponent implements OnInit {

  Furnitures!: furnitures[];
  constructor( private auth: AuthService, private furnituresService: furnituresService ){ }

  ngOnInit(): void {

    this.furnituresService.getAllfurnitures().subscribe((data : furnitures[]) => {
      this.Furnitures = data;
    })
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
