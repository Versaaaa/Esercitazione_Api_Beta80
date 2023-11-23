import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiRepositoryService } from '../api-repository.service';

@Component({
  selector: 'app-functionality-manager',
  templateUrl: './functionality-manager.component.html',
  styleUrls: ['./functionality-manager.component.css']
})
export class FunctionalityManagerComponent {

  a: string = "2";

  bank: any;
  functionalities: any[] = [];

  bankFunctionalies: {idBanca: number, idFunzionalita: number}[] = [];

  checkboxes: {functionId: number, active: boolean}[] = [];

  constructor(private repo: ApiRepositoryService, private route: ActivatedRoute) {

    repo.GetFunctionalities().subscribe(x => {
      this.functionalities = x;
      this.functionalities.splice(1, 1);
    });
    
    route.url.subscribe(x => {
      repo.getBank(Number(x[0].path)).subscribe(x => {
        this.bank = x;
      });
      
      repo.GetFunctionalitiesByBankId(Number(x[0].path)).subscribe(x => {
        this.checkboxes = [];
        this.functionalities.forEach((y: any) => {
          this.checkboxes.push({functionId: y.id, active: false});
        });
        
        this.bankFunctionalies = x;
        x.forEach((y: any) => {
          let res = this.checkboxes.find(z => z.functionId == y.idFunzionalita);
          if (res) {
            res.active = true;
          }
        });
      })
    });
  }

  update() {
    this.checkboxes.forEach(checkbox => {
      if (checkbox.active){
        if(this.bankFunctionalies.find(x => x.idFunzionalita == checkbox.functionId) === undefined) {
          this.repo.PostBankFunction(this.bank.id, checkbox.functionId);
        }
      }
      else{
        if(this.bankFunctionalies.find(x => x.idFunzionalita == checkbox.functionId)) {
          this.repo.DeleteBankFunction(this.bank.id, checkbox.functionId);
        }
      }
    });
  }

  findCheckbox(functionId: number): boolean {
    let res = this.checkboxes.find(x => x.functionId == functionId);
    if (res) {
      return res.active;
    }
    return false
  }

  toggleCheckbox(functionId: number): void {
    let res = this.checkboxes.find(x => x.functionId == functionId);
    if (res) {
      res.active = !res.active;
    }
  }

}
