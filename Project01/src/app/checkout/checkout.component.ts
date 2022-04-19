import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  Total:number = 0;

  constructor(private auth: AuthService) {

    this.auth.totalSubject.subscribe(data=>{
      this.Total = data;
      console.log(this.Total);
    });
  }

  ngOnInit(): void {

  }


}
