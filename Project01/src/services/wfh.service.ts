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

    return this.httpClient.get<wfh[]>("http://localhost:3000/wfh",
    {
      headers: {

        "Access-Control-Allow-Origin": "*"

      }

    })

  }
}
