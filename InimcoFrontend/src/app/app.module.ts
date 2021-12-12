import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import  { HttpClientModule } from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ProfileCreationComponent } from './components/profilecreation/profilecreation.component';
import { ProfilecreationformComponent } from './components/profilecreationform/profilecreationform.component';
import { ImputWithLabelComponent } from './components/inputwithlabel/inputwithlabel.component';
import { ButtonComponent } from './components/button/button.component';

@NgModule({
  declarations: [
    AppComponent,
    ProfileCreationComponent,
    ProfilecreationformComponent,
    ImputWithLabelComponent,
    ButtonComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
