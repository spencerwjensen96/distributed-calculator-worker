import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-health-check',
  templateUrl: './health-check.component.html'
})
export class HealthCheckComponent {

  returnMessage: HealthCheckReturn = { Message: '' };
  errorMessage: string = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  }

  checkAPIHealth() {
    this.http.post<HealthCheckReturn>('https://localhost:7000/health-check',{}).subscribe(result => {
      this.returnMessage = result;
    }, error => this.errorMessage = `POST to health-check failed with message: ${error.message}`);
  }
}

interface HealthCheckReturn {
  Message: string
}
