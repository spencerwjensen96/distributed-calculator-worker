import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  constructor(private http: HttpClient) {
  }

  snippet1 = `{
    "jobId": "&lt;guid&gt;",
    "calculation": "CALCULATE: &lt;problem to solve&gt;"
  }`;
  snippet2 = `{
    "jobId": "&lt;guid&gt;",
    "result": "&lt;solution&gt;"
  }`;
  snippet3 = `{
    "jobId": "&lt;guid&gt;",
    "errorMessage": "&lt;error message&gt;"
  }`;
  snippet4 = `{
    "workerId": "&lt;guid you generate&gt;",
    "teamName": "&lt;so we know who to talk to about the worker&gt;",
    "createJobEndpoint": "&lt;the URL that will receive the jobs&gt;",
    "errorCheckEndpoint": "&lt;the URL that will receive error messages&gt;"
  }`;
  snippet5 = `{
    "result": "&lt;a message describing the registration outcome&gt;"
  }`;

  createJob() {
    this.http.post<CreateJobReturn>('https://localhost:7000/createJob',{
      JobId: "19c5530d-0274-48b0-a021-5dace3c6695d",
      Calculation: "CALCULATE: 2 + 2"
    }).subscribe(response => {
      console.log(response);
    }, error => `POST to createJob failed with message: ${error.message}`);
  }

  errorCheck() {
    this.http.post<ErrorCheckReturn>('https://localhost:7000/errorCheck',{
      JobId: "19c5530d-0274-48b0-a021-5dace3c6695d",
      ErrorMessage: "Example Error Message"
    }).subscribe(response => {
      console.log(response);
    }, error => `POST to errorCheck failed with message: ${error.message}`);
  }
}

interface CreateJobReturn {
  result: string;
}

interface ErrorCheckReturn {
  result: string;
}
