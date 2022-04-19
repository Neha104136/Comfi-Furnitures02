import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { furnitures } from './furnitures';
import { Observable } from 'rxjs';

@Injectable({

  providedIn: 'root'

})

export class furnituresService {

  constructor(private httpClient: HttpClient ) { }

  getAllfurnitures() : Observable<furnitures[]>{

    return this.httpClient.get<furnitures[]>("https://localhost:44397/furnitures/GetAllProducts",
    {
      headers: {

        "Access-Control-Allow-Origin": "*"

      }

    })

  }
}
