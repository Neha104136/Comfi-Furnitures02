import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { wfh } from './wfh';
import { Observable } from 'rxjs';

@Injectable({

  providedIn: 'root'

})

export class wfhService {

  constructor(private httpClient: HttpClient ) { }

  getAllwfh() : Observable<wfh[]>{

    return this.httpClient.get<wfh[]>("https://localhost:44397/Wfhs/GetAllProducts",
    {
      headers: {

        "Access-Control-Allow-Origin": "*"

      }

    })

  }
}
