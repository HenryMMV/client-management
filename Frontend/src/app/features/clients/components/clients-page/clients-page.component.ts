import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ClientsService } from '../../services/clients.service';
import { Client } from '../../models/client.model';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-clients-page',
  templateUrl: './clients-page.component.html'
})
export class ClientsPageComponent implements OnInit {
  searchControl = new FormControl('', { nonNullable: true });
  loading = false;
  clients: Client[] = [];
  filtered: Client[] = [];
  error: string | null = null;

  constructor(private clientsService: ClientsService) {}

  ngOnInit(): void {
    this.fetchClients();
    this.searchControl.valueChanges.pipe(debounceTime(300)).subscribe(ruc => {
      this.filterByRuc(ruc);
    });
  }

  fetchClients(): void {
    this.loading = true;
    this.clientsService.getClients().subscribe({
      next: data => {
        this.clients = data;
        this.filtered = data;
        this.loading = false;
      },
      error: err => {
        this.error = 'Error cargando clientes';
        this.loading = false;
        console.error(err);
      }
    });
  }

  filterByRuc(ruc: string): void {
    if (!ruc) {
      this.filtered = this.clients;
      return;
    }
    this.filtered = this.clients.filter(c => c.ruc.includes(ruc));
  }
}
