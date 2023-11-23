import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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

  GetFunctionalities(): Observable<any> {
    let res;
    res = this.httpClient.get(this.baseUrl + "/Funzionalita");  
    return res;
  }

  GetFunctionalitiesByBankId(id: number): Observable<any> {
    let res;
    res = this.httpClient.get(this.baseUrl + `/BancheFunzionalita/${id}`);  
    return res;
  }

  async PostBankFunction(bankId: number, functionId: number): Promise<any> {
    let res; 
    let body = {
      idBanca : bankId,
      idFunzionalita: functionId
    }

    console.log(body);

    await this.httpClient.post(this.baseUrl + "/BancheFunzionalita", body).toPromise().then(x => res = x).catch(x=> res = x);
    return res;

  }

  async DeleteBankFunction(bankId: number, functionId: number): Promise<any> {
    let res; 
    let options = {
      body: {
        idBanca : bankId,
        idFunzionalita: functionId
      }
    }
    await this.httpClient.delete(this.baseUrl + "/BancheFunzionalita", options).toPromise().then(x => res = x).catch(x => res = x);
    return res; 
  }

  GetBanks(): Observable<any> {
    let res;
    res = this.httpClient.get(this.baseUrl + "/Banche");  
    return res;
  }

  getBank(bankId: number): Observable<any> {
    let res;
    res = this.httpClient.get(this.baseUrl + "/Banche/" + bankId)
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
