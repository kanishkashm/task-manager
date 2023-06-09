import { Injectable } from '@angular/core';
import { Constants } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class ApiEndpointService {

  constructor(
    private constants: Constants
  ) { }

  public createUrl(
    uslSuffix: string,
  ): string {
    const url: string = `${this.constants.API_ENDPOINT}/${uslSuffix}`;
    return url;
  }
}
