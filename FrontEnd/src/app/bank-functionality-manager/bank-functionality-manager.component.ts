import { Component } from '@angular/core';
import { ApiRepositoryService } from '../api-repository.service';

@Component({
  selector: 'app-bank-functionality-manager',
  templateUrl: './bank-functionality-manager.component.html',
  styleUrls: ['./bank-functionality-manager.component.css']
})

export class BankFunctionalityManagerComponent {

  banks: {id: number, nome: string}[] = [];

  constructor(private repo: ApiRepositoryService) 
  {
    repo.GetBanks().subscribe(x => 
      {
        this.banks = x;
      });
  }
}
