import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-user-delete-dialog',
  templateUrl: './user-delete-dialog.component.html',
  styleUrls: ['./user-delete-dialog.component.css']
})
export class UserDeleteDialogComponent {

  constructor(public dialogRef: MatDialogRef<UserDeleteDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: {id: number, nomeUtente:string, banca: string, bloccato: boolean}) {}
  delete() 
  {
    this.dialogRef.close(true);
  }
}
