import { Component, OnInit } from '@angular/core';
import { Cliente } from 'src/app/cadastro/models/cliente';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit{
  public todayDate = new Date();
  customers: Cliente[] = []

  constructor(private api: ClienteService) {
  }
  
  ngOnInit(){
    this.api.getCustomers().subscribe(data => {
      this.customers = data;
    });
  }

  excluirCliente(id: string) {
    this.api.deleteCustomer(id).subscribe(data => {
      alert(data);
      location.reload();
    });
  }
}

