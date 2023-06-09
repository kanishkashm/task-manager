import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root',
  })
export class Constants {
    public readonly API_ENDPOINT: string = `${environment.apiBaseUrl}/api/v1`;
}