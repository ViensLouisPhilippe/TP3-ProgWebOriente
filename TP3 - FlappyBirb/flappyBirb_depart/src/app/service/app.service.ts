import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { last, lastValueFrom } from 'rxjs';
import { Score } from '../models/score';

@Injectable({
  providedIn: 'root'
})
export class AppService {

constructor(public http: HttpClient) { }

  async register(username : string, email : string, password: string, confirmPassword: string) : Promise<void>{
    let registerDTO = {username : username, email: email, password : password, confirmPassword : confirmPassword};
    let x = await lastValueFrom(this.http.post<any>("https://localhost:7093/api/users/register", registerDTO))
    console.log(x);
    localStorage.setItem("token", x.token);
  }

  async login(username : string, password: string): Promise<void>{
    let loginDTO = {user : username, pwrd : password};
    let x = await lastValueFrom(this.http.post<any>("https://localhost:7093/api/users/login", loginDTO))
    console.log(x);
    localStorage.setItem("token", x.token);
  }

  async getScores() : Promise<void>{
    let token = localStorage.getItem("token");
    let httpsOptions = {
      header: new HttpHeaders({
        'Content-Type' : 'application/json', 'Authorization' : 'Bearer ' + token
      })
    };
    let x = await lastValueFrom(this.http.get<Score[]>("eventuel ajouter le nom du lien", httpsOptions));
    console.log(x);
  }

}
