import { Component } from '@angular/core';
import { ApiRepositoryService } from '../api-repository.service';
import { HttpResponseBase } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { UserUpdateDialogComponent } from '../user-update-dialog/user-update-dialog.component';
import { UserDeleteDialogComponent } from '../user-delete-dialog/user-delete-dialog.component';

@Component({
  selector: 'app-user-manager',
  templateUrl: './user-manager.component.html',
  styleUrls: ['./user-manager.component.css']
})
export class UserManagerComponent {

  columnsToDisplay: string[] = ["nomeUtente", "banca", "bloccato"]

  data: Array<{id: number, nomeUtente:string, banca: string, bloccato: boolean}> = [];
  banks: Array<any> = [];

  dataObs: Observable<any>;
  banksObs: Observable<any>;

  res_msg: string = "";

  username: string = "";
  password: string = "";

  constructor (public repo: ApiRepositoryService, public dialog: MatDialog) {
    this.banksObs = this.repo.GetBanks();
    this.dataObs = this.repo.GetUsers();
    this.loadObservables();
  }

  loadObservables(): void{
    this.dataObs.subscribe(x => {this.data = x;});
    this.banksObs.subscribe(x => {this.banks = x;});
  }

  submit(bankId:string) {
    if(this.username === "" || this.password === "") {
      this.res_msg = "Password o Username Mancanti";
      console.log("errore");
    }
    else{
      this.res_msg = "";
      this.repo.PostUsers(Number(bankId), this.username, this.password).then((res) => 
      {
        if(res.error as HttpResponseBase) {
          console.log(res);
          this.res_msg = res.error;
        }
        else{
          console.log("Successo");
          this.loadObservables();
          this.res_msg = "Utente creato con Successo";

          this.username = "";
          this.password = "";

        }
      });
    }
  }

  update(user: any) {
    console.log(user)
    this.dialog.open(UserUpdateDialogComponent, {data: user, width: "80%"}).afterClosed().subscribe(x => {
      console.log(x);
      if(x) {
        this.repo.PutUsers(x.id, x.password, x.bloccato).then(x => this.loadObservables());
      }
    });
  }
  
  delete(user: any) {
    console.log(user)
    this.dialog.open(UserDeleteDialogComponent, {data:user, width: "60%"}).afterClosed().subscribe(x => {
      console.log(x);
      if(x){
        this.repo.DeleteUsers(user.id).then(x => this.loadObservables());
      }
    })
  }

}
