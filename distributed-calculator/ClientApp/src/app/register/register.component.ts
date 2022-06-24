import { Component } from '@angular/core';

@Component({
  selector: 'app-register-component',
  templateUrl: './register.component.html'
})
export class RegisterComponent {

  public registrationSuccessful: boolean = false;

  registerWorker(){
    this.registrationSuccessful = true;
    console.log("register");
  }
}
