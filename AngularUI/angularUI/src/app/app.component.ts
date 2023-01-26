import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  activeButton: string = 'employeeButton';

  setActive(buttonName: string) {
    this.activeButton = buttonName;
  }
}
