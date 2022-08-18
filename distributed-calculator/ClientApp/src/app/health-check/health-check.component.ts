import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-health-check',
  templateUrl: './health-check.component.html'
})
export class HealthCheckComponent {

  returnMessage: HealthCheckReturn = { message: '' };
  errorMessage: string = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private cRef: ChangeDetectorRef) {
  }

  checkAPIHealth() {
    this.http.get<HealthCheckReturn>('https://localhost:7000/health-check',{}).subscribe(result => {
      this.returnMessage.message = result.message;
    }, error => this.errorMessage = `GET to health-check failed with message: ${error.message}`);
    this.cRef.detectChanges();
  }
}

interface HealthCheckReturn {
  message: string
}
