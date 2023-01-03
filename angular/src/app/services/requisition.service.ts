import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AddRequisition } from '../models/requisition/addrequisition';
import { Currency, Department, Requisition } from '../models/requisition/req-list.model';
import { Skill } from '../models/skill';

@Injectable({
  providedIn: 'root'
})
export class RequisitionService {
  base_url: string = environment.base_url;

  constructor(private http: HttpClient) { }
  getRequisitionDetails(id: string): Observable<Requisition> {
    console.log(id)
    return this.http.get<Requisition>(this.base_url + '/api/RequisitionDetail/' + id);
  }
  public GetAllCountry = (): Observable<any> => {
    return this.http.get(this.base_url + '/api/Country/');
  }

  getAllSkil(): Observable<Skill[]> {
    return this.http.get<Skill[]>(this.base_url + '/api/SKills/Skills');
  }

  getAllDepartments(): Observable<Department[]> {
    return this.http.get<Department[]>(this.base_url + '/api/Department');
  }

  getAllCurrency(): Observable<Currency[]> {
    return this.http.get<Currency[]>(this.base_url + '/api/Department/Currency');
  }

  addRequisition(addRequisitionRequest: AddRequisition): Observable<AddRequisition> {
    addRequisitionRequest.requisitionID = 'c80d820c-61be-4a2b-9b28-de8590192366';  
     return this.http.post<AddRequisition>(this.base_url + '/api/Requisition', addRequisitionRequest);
  }
}
