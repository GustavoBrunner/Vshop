import { Component, Inject } from '@angular/core';
import { IClientService, IClientServiceToken } from '../../../services/contracts/IClientService';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrl: './client.component.css'
})
export class ClientComponent  {
  constructor(@Inject(IClientServiceToken) private clientService: IClientService){}

  //table attributes
  isShowTable: boolean = true;

  //form attributes
  isShowForm: boolean = false;
}
