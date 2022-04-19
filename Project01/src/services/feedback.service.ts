import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { feedback } from './feedback';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  private data : feedback[] = [
    {first_name:"abc",last_name:"xyz",email:"abc@gmail.com",suggestions:"Awesome products"}
  ];

  constructor(private httpClient: HttpClient) { }
  getfeedback(): feedback[]{
    return this.data;
  }

  addCustomer(feedback : feedback):void{
    this.data.push(feedback);
  }
  submitUser(user:any){
    return this.httpClient.post("http://localhost:3000/feedback",user,
    {

     headers:{
       "Access-Control-Allow-Origin":"*"
     }

    })

   }
}






