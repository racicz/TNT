import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegistrationDto } from '../model/request/user.model';
import { RegistrationResponseDto } from '../model/response/user.response.model';
import { EnvironmentUrlService } from './environment-url.service';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private _http: HttpClient, 
              private _envUrl: EnvironmentUrlService) { }


  public registerUser = (route: string, body: RegistrationDto) => {
    return this._http.post<RegistrationResponseDto> (this.createCompleteRoute(route, this._envUrl.urlAddress), body);
  }
  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}
