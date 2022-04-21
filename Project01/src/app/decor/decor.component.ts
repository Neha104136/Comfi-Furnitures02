import { Component,Inject, OnInit } from '@angular/core';
import { decorService } from '../../services/decor.service'
import { decor } from '../../services/decor';
import { AuthService } from '../../services/auth.service';

@Inject(decorService)

@Component({
  selector: 'app-decor',
  templateUrl: './decor.component.html',
  styleUrls: ['./decor.component.css']
})
export class DecorComponent implements OnInit {

  Decor!: decor[];
  constructor( private auth: AuthService, private decorService: decorService ) { }

  ngOnInit(): void {

    this.decorService.getAlldecor().subscribe((data : decor[]) => {
      this.Decor = data;
    })
  }

  // incQnt(prod:any){

  //   if(prod.prodquantity != 5){
  //     prod.prodquantity += 1;
  //   }
  // }

  // decQnt(prod:any){
  //   if(prod.prodquantity != 1){
  //     prod.prodquantity -= 1;
  //   }
  // }

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
