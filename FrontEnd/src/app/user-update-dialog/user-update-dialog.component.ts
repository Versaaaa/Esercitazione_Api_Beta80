import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-user-update-dialog',
  templateUrl: './user-update-dialog.component.html',
  styleUrls: ['./user-update-dialog.component.css']
})
export class UserUpdateDialogComponent{

  result: {id: number, password: string, bloccato: boolean} = {id: -1, password: "string", bloccato: false};

  constructor(public dialogRef: MatDialogRef<UserUpdateDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: {id: number, nomeUtente:string, banca: string, bloccato: boolean}) 
  {

  }

  getResult(id: number, password: string, verify_password: string, bloccato: string) 
  {
    if(verify_password == password) {
      this.result = {id: id, password: password, bloccato: bloccato == "true"}
      this.dialogRef.close(this.result);
    }
  }
}
