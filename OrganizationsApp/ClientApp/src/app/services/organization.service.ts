
import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root',
})
export class OrganizationService {

  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getCount(): Observable<any> {
    return this.http.get(this.baseUrl + `api/Organization/Count`);
  }

  get(pageNumber, searchString): Observable<any> {
    return this.http.get(this.baseUrl + `api/Organization/Get/${pageNumber}?searchText=${searchString}`)
  }
  getById(id): Observable<any> {
    return this.http.get(this.baseUrl + `api/Organization/${id}`)
  }
  create(person): Observable<any> {
    return this.http.post(this.baseUrl + `api/Organization/Create`, person)
  }
  update(person): Observable<any> {
    return this.http.post(this.baseUrl + `api/Organization/Update`, person)
  }
  delete(id): Observable<any> {
    return this.http.post(this.baseUrl + `api/Organization/Delete/${id}`, {});
  }
  addPersonToOrganization(value): Observable<any> {
    return this.http.post(this.baseUrl + `api/Organization/AddPersonToOrganization`, value)
  }
  getPersonOrganizations(id): Observable<any> {
    return this.http.get(this.baseUrl + `api/Organization/GetPersonOrganizations/${id}`);
  }
}
