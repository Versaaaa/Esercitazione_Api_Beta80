import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WelcomePageComponent } from './welcome-page/welcome-page.component';
import { UserManagerComponent } from './user-manager/user-manager.component';
import { FunctionalityManagerComponent } from './functionality-manager/functionality-manager.component';
import { BankFunctionalityManagerComponent } from './bank-functionality-manager/bank-functionality-manager.component';

const routes: Routes = [
  {
    path: '',
    component: WelcomePageComponent,
    title: 'Home page'
  },
  {
    path: 'user',
    component: UserManagerComponent,
    title: 'Gestione Utenti'
  },
  {
    path: 'functionality',
    component: BankFunctionalityManagerComponent,
    title: 'Gestione Funzionalità',
    children:
    [
      {
        path: ':id',
        component: FunctionalityManagerComponent,
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
