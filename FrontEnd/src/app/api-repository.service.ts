import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})

export class ApiRepositoryService {

  readonly baseUrl: string = "https://localhost:7075/api";
  httpClient: HttpClient;

  constructor(httpClient: HttpClient) 
  {
    this.httpClient = httpClient;
  }

  GetBanks(): Observable<any> {
    let res;
    res = this.httpClient.get(this.baseUrl + "/Banche");  
    return res;
  }

  GetUsers(): Observable<any> {
    let res;
    res = this.httpClient.get(this.baseUrl + "/Utenti");  
    return res;
  }

  async PostUsers(bankId:number, username:string, password:string): Promise<any> {
    let res;
    let body = {
      idBanca: bankId,
      nomeUtente: username,
      password: password
    };
    await this.httpClient.post(this.baseUrl + "/Utenti", body).toPromise().then(x => res = x).catch(x => res = x);
    return res;
  }

  async PutUsers(userId: number, password: string, bloccato: boolean): Promise<any> {
    let res;
    let body = {
      password: password,
      bloccato: bloccato,
    };
    console.log(body);
    await this.httpClient.put(this.baseUrl + "/Utenti/" + userId, body).toPromise().then(x => res = x).catch(x => res = x);
    return res;
  }

  async DeleteUsers(userId: number): Promise<any> {
    let res;
    await this.httpClient.delete(this.baseUrl + "/Utenti/" + userId).toPromise().then(x => res = x).catch(x => res = x);
    return res; 
  }

}
