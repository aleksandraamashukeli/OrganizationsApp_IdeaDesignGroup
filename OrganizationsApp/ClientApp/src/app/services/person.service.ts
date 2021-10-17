
import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root',
})
export class PersonService {

  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getCount(): Observable<any> {
    return this.http.get(this.baseUrl + `api/Person/Count`);
  }

  get(pageNumber, searchString): Observable<any>{
    return this.http.get(this.baseUrl + `api/Person/Get/${pageNumber}?searchText=${searchString}`)
  }
  getById(id): Observable<any> {
    return this.http.get(this.baseUrl + `api/Person/${id}`)
  }
  create(person): Observable<any> {
    return this.http.post(this.baseUrl + `api/Person/Create`, person)
  }
  update(person): Observable<any> {
    return this.http.post(this.baseUrl + `api/Person/Update`, person)
  }
  delete(id): Observable<any> {
    return this.http.post(this.baseUrl + `api/Person/Delete/${id}`, {});
  }
  getForOrganization(organizationId): Observable<any> {
    return this.http.get(this.baseUrl + `api/Person/GetForOrganization/${organizationId}`)
  }
}
