import { EmailValidator } from "@angular/forms";

export class feedback
{
  [x: string]: any;

  FirstName: string;
  LastName: string;
  Email: string;
  Suggestions: string;

  constructor(FirstName:string, LastName:string, Email:string, Suggestions:string){

    this.FirstName = FirstName;
    this.LastName = LastName;
    this.Email = Email;
    this.Suggestions = Suggestions;
}
}
