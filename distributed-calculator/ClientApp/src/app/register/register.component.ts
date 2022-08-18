import { Component } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Guid } from "guid-typescript";

@Component({
  selector: 'app-register-component',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  public registrationSuccessful: boolean = false;
  public registrationReturn: RegistrationReturn = {result: ""};
  public registrationRequest: RegistrationRequest = { url: '', id: Guid.create(), workerName: '', createJobEndpoint: 'createJob', errorCheckEndpoint: 'errorCheck'};
  public errorMessage: string = "";
  isValidHostname: boolean = this.registrationRequest.url != '';

  constructor(private http: HttpClient) {
  }

  registerWorker(){
    this.http.post<RegistrationReturn>(`https://localhost:7000/register`, this.registrationRequest).subscribe(result => {
      this.registrationReturn = result;
    }, error => this.errorMessage = `Error occured when trying to register at https://${this.registrationRequest.url}/register. Check your hostname.`);
    this.errorMessage ? this.registrationSuccessful = true : '';
  }

  changeEndpoint() {

  }
}
interface RegistrationRequest{
  url: string;
  id: Guid;
  workerName: string;
  createJobEndpoint: any;
  errorCheckEndpoint: any;
}

interface RegistrationReturn{
 result: string;
}
