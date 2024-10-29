import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

import { ClientService } from '../services/client.service';
import { Client, ClientInput } from '../../shared/models/client.model';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrl: './client.component.css'
})
export class ClientComponent implements OnInit {

  public static path: string = 'clients';

  @ViewChild('clientUploadInput') fileInput!: ElementRef;
  
  public clients: Client[] = [];
  public model: ClientInput = {
    identificationNumber: '',
    age: 0,
    phoneNumber: '',
    names: '',
    lastNames: ''
  };

  constructor(private service: ClientService) {}

  ngOnInit(): void {
    this.getAllClients();
  }

  getAllClients() {
    this.service
    .getClients()
    .subscribe({
      next: (clients: Client[]) => {
        this.clients = clients;
      },
      error: (err) => {
        console.error(err);
      }
    });
  }

  uploadClients(event: any) {
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.onload = (e) => {
      this.readFile(reader.result);
    };
    reader.readAsText(file);
    this.resetUpload();
  }
  
  resetUpload() {
    this.fileInput.nativeElement.value = "";
  }

  readFile(result: string | ArrayBuffer | null) {
    if (result) {
      let lines = (result as string).trim().split('\n');
      let contents = lines.map(l => l.split(','));
      let payload: ClientInput[] = contents.map(c =>
      ({
        identificationNumber: c[0],
        names: c[1],
        lastNames: c[2], 
        age: c[3],
        phoneNumber: c[4],
      }));

      this.service
        .addClients(payload)
        .subscribe({
          next: () => this.getAllClients(),
          error: (err) => {
            alert('Ocurrió un error al cargar los datos. Revise la información e intente nuevamente.')
            console.error(err);
          }
        });
    }
  }

}
