import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  images = [
    '../../assets/Banner/Banner01.jpg',
    '../../assets/Banner/Banner02.jpg',
    '../../assets/Banner/Banner03.png'
  ];

}
