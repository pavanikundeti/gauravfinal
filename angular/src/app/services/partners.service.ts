import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Partner } from '../models/partner.model'

@Injectable({
  providedIn: 'root'
})
export class PartnersService {
  base_url: string = environment.base_url;

  constructor(private http: HttpClient) { }
  getAllPartners(): Observable<Partner[]> {
   return this.http.get<Partner[]>(this.base_url + '/api/partners');

  }
  getPartnerDetails(id: string): Observable<Partner> {
    return this.http.get<Partner>(this.base_url + '/api/partners/' + id);
  }
  //getPartner(id: string): Observable<Partner> {
  //  return this.http.get<Partner>(this.base_url + '/api/partners/' + id)
  //}
  //getOnePartner(id): Observable<Partner[]> {
  //  return this.http.get<Partner[]>(this.base_url + id)
  //}
  deletePartner(id: string): Observable<Partner> {
    return this.http.delete<Partner>(this.base_url + '/api/partners/' + id);
  }
  //delete(id: string): Observable<Partner> {
  //  return this.http.delete<Partner>(`${this.base_url}/${id}`);
  //}
}
