import { Observable } from "rxjs";
import { Client } from "../../models/client";
import { InjectionToken } from "@angular/core";

export const IClientServiceToken = new InjectionToken<IClientService>('ClientServiceToken');

export interface IClientService{
    createClient(client: Client): any;
    getAll(): Observable<Client[]>;
    getById(id: string): Observable<Client>;
    updateClient(client: Client): any;
    deleteClient(id: string): any;
}