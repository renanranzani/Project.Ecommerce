import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RegistrationComponent } from './Registration/registration/registration.component';
import { DetailsComponent } from './Details/details/details.component';
import { GridComponent } from './Grid/grid/grid.component';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    DetailsComponent,
    GridComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
