import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IClientService } from '../contracts/IClientService';
import { Observable } from 'rxjs';
import { Client } from '../../models/client';

const header = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ClientService implements IClientService {
  constructor(private client: HttpClient) { }

  url = 'api/client/';

  createClient(client: Client) {
    return this.client.post<any>(this.url, client, header);
  }
  getAll(): Observable<Client[]> {
    return this.client.get<Client[]>(this.url);
  }
  getById(id: string): Observable<Client> {
    const newUrl = this.url + id;
    return this.client.get<Client>(newUrl);
  }
  updateClient(client: Client) {
    return this.client.put<any>(this.url, header);
  }
  deleteClient(id: string) {
    const newUrl = this.url + id;
    return this.client.delete<any>(newUrl, header);
  }
}
