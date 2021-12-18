import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API_URL } from 'src/app/app.module';
import { Company } from '../models/company';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private _http: HttpClient,
    @Inject(API_URL) private _url: string) { }

  getItems(): Observable<Company[]> {
    const address = this._url + "company";
    return this._http.get<Company[]>(address);
  }

  postItem(company: Company): Observable<Company> {
    return this._http.post<Company>(this._url + "company", company);
  }

  editItem(company: Company): Observable<any> {
    return this._http.patch(`${this._url}company/${company.Id}`, company);
  }
} 
