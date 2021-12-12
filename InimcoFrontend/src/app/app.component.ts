import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title: string = 'InimcoFrontend';
  number: number = 0;

  Add() : void {
    this.number++;
  }
}
