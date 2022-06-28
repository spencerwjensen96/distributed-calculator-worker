import { Component } from '@angular/core';
import {HttpClient, HttpHandler} from '@angular/common/http';

@Component({
  selector: 'app-register-component',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  public registrationSuccessful: boolean = false;
  public registrationReturn: RegistrationReturn = {result: ""};
  public registrationRequest: RegistrationRequest = { workerName: '', createJobEndpoint: 'createJob', errorCheckEndpoint: 'errorCheck'};
  public hostname: string = "";
  public errorMessage: string = "";
  isValidHostname: boolean = this.hostname != '';

  constructor(private http: HttpClient) {
  }

  registerWorker(){
    this.http.post<RegistrationReturn>(`https://${this.hostname}/register`, this.registrationRequest).subscribe(result => {
      this.registrationReturn = result;
    }, error => this.errorMessage = `Error occured when trying to register at https://${this.hostname}/register. Check your hostname.`);
    this.errorMessage ? this.registrationSuccessful = true : '';
  }

}
interface RegistrationRequest{
  workerName : string;
  createJobEndpoint: any;
  errorCheckEndpoint: any;
}

interface RegistrationReturn{
 result: string;
}
