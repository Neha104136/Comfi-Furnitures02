import { EmailValidator } from "@angular/forms";

export class feedback
{

  first_name: string;
  last_name: string;
  email: string;
  suggestions: string;

  constructor(first_name:string, last_name:string, email:string, suggestions:string){

    this.first_name = first_name;
    this.last_name = last_name;
    this.email = email;
    this.suggestions = suggestions;
}
}
