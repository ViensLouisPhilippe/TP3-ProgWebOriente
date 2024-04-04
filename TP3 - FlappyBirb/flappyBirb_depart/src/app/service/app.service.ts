import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { last, lastValueFrom } from 'rxjs';
import { Score } from '../models/score';
import { DecimalPipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class AppService {

constructor(public http: HttpClient) { }

  async register(name : string, email : string, password: string, confirmPassword: string) : Promise<void>{
    let registerDTO = {username : name, email: email, password : password, passwordConfirm : confirmPassword};
    let x = await lastValueFrom(this.http.post<any>("https://localhost:7074/api/users/register", registerDTO))
    console.log(x);

  }

  async login(username : string, password: string): Promise<void>{
    let loginDTO = {username : username, password : password};
    let x = await lastValueFrom(this.http.post<any>("https://localhost:7074/api/users/login", loginDTO))
    console.log(x);
    localStorage.setItem("token", x.token);
  }

  async getMyScore() : Promise<Score[]>{
    let token = localStorage.getItem("token");
    let httpsOptions = {
      headers: new HttpHeaders({
        'Content-Type' : 'application/json', 'Authorization' : 'Bearer ' + token
      })
    };
    let x = await lastValueFrom(this.http.get<Score[]>("https://localhost:7074/api/scores/getPublicScores", httpsOptions));
    console.log(x);
    return x;
  }

  async getScores() : Promise<Score[]>{
    let token = localStorage.getItem("token");
    let httpsOptions = {
      headers: new HttpHeaders({
        'Content-Type' : 'application/json', 'Authorization' : 'Bearer ' + token
      })
    };
    let x = await lastValueFrom(this.http.get<Score[]>("https://localhost:7074/api/scores/getPublicScores", httpsOptions));
    console.log(x);
    return x;
  }

  async postScore(score : string, temps: string) : Promise<void>{
    let token = localStorage.getItem("token");
    let httpsOptions = {
      headers: new HttpHeaders({
        'Content-Type' : 'application/json', 'Authorization' : 'Bearer ' + token
      })
    };
    let parsedTemps = JSON.parse(temps);
    let parsedScore = JSON.parse(score);

    let newScore = new Score(0, null, null, parsedTemps, parsedScore, true);

    let x = await lastValueFrom(this.http.post<Score>("https://localhost:7074/api/scores/postscore", newScore, httpsOptions));
    console.log(x);


  }
}
