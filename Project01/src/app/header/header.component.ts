import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private auth: AuthService) {
    this.auth.cartSubject.subscribe((data)=>{
      this.cartItem = data;
    });

  }

  ngOnInit(): void {
    this.cartItemFunc();
  }

  cartItem:number = 0;
  cartItemFunc(){
    if(localStorage.getItem('localCart') != null){
      var cartCount = JSON.parse(localStorage.getItem('localCart') || '{}');
      this.cartItem = cartCount.length;
    }
  }
}
