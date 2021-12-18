import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyComponent } from './dashboard/pages/company/company.component';
import { CustomerComponent } from './dashboard/pages/customer/customer.component';

const routes: Routes = [
  {path: "", redirectTo: "company", pathMatch: "full"},
  {path: "company", component: CompanyComponent},
  {path: "customer", component: CustomerComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
