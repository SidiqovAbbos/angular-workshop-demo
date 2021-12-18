import { InjectionToken, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from './material.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CompanyComponent } from './dashboard/pages/company/company.component';
import { CustomerComponent } from './dashboard/pages/customer/customer.component';
import { HttpClientModule } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CompanyDialogComponent } from './dashboard/pages/company/company-dialog/company-dialog.component';

export const API_URL = new InjectionToken<string>("api url");

@NgModule({
  declarations: [	
    AppComponent,
    DashboardComponent,
    CompanyComponent,
    CustomerComponent,
    CompanyDialogComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    MaterialModule,
    HttpClientModule
  ],
  providers: [
    {provide: API_URL, useValue: environment.apiUrl}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
