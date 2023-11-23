import { NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { WelcomePageComponent } from './welcome-page/welcome-page.component';
import { UserManagerComponent } from './user-manager/user-manager.component';
import { UserUpdateDialogComponent } from './user-update-dialog/user-update-dialog.component';
import { UserDeleteDialogComponent } from './user-delete-dialog/user-delete-dialog.component';
import { FunctionalityManagerComponent } from './functionality-manager/functionality-manager.component';
import { BankFunctionalityManagerComponent } from './bank-functionality-manager/bank-functionality-manager.component';

@NgModule({
  declarations: [
    AppComponent,
    WelcomePageComponent,
    UserManagerComponent,
    UserUpdateDialogComponent,
    UserDeleteDialogComponent,
    FunctionalityManagerComponent,
    BankFunctionalityManagerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatDialogModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
