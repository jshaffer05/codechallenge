import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {
  private apiUrl = 'http://localhost:5273/api/Calculator';

  constructor(private http: HttpClient) { }

  add(){
    return this.http.get(`${this.apiUrl}/add`)
  }

  subtract(){
    return this.http.get(`${this.apiUrl}/subtract`)
  }

  divide(){
    return this.http.get(`${this.apiUrl}/divide`)
  }

  multiply(){
    return this.http.get(`${this.apiUrl}/multiply`)
  }

  pos1(num: number){
    return this.http.get(`${this.apiUrl}/pos1?number=${num}`)
  }

  pos2(num: number){
    return this.http.get(`${this.apiUrl}/pos2?number=${num}`)
  }

  get(position: number){
    return this.http.get(`${this.apiUrl}/position?location=${position}`)    
  }

  clear(currentPosition: number){
    return this.http.get(`${this.apiUrl}/clear?location=${currentPosition}`)        
  }


}
