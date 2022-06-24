import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-health-check',
  templateUrl: './health-check.component.html'
})
export class HealthCheckComponent {

  returnMessage: HealthCheckReturn = { Message: '' };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.post<HealthCheckReturn>('https://localhost:7000/health-check',{}).subscribe(result => {
      this.returnMessage = result;
    }, error => console.error(error));
  }
}

interface HealthCheckReturn {
  Message: string
}
