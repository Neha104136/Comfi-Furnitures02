import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { feedback } from './feedback';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  private data : feedback[] = [
    {FirstName:"abc",LastName:"xyz",Email:"abc@gmail.com",Suggestions:"Awesome products"}
  ];

  constructor(private httpClient: HttpClient) { }
  getfeedback(): feedback[]{
    return this.data;
  }

  addCustomer(feedback : feedback):void{
    this.data.push(feedback);
  }



  submitUser(user:any){
    console.log(user);
    return this.httpClient.post("https://localhost:44397/api/Feedbacks1",user,
    {

     headers:{
       "Access-Control-Allow-Origin":"*"
     }

    })

   }
}






