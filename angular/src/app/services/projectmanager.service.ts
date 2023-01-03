import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ProjectManager } from '../models/projectmanager.model';
import { ProjectManagerAdd } from '../models/projectmanageradd.model';

@Injectable({
  providedIn: 'root'
})
export class ProjectmanagerService {
  baseApiUrl: string = environment.base_url;
  constructor(private http: HttpClient) { }
  getProjectManagers(): Observable<ProjectManager[]> {
    return this.http.get<ProjectManager[]>(this.baseApiUrl + '/api/ProjectManager');
  }
  addEmployee(addProjectManagerRequest: ProjectManagerAdd): Observable<ProjectManagerAdd> {
    addProjectManagerRequest.projectManagerID = 'c80d820c-61be-4a2b-9b28-de8590192366';
    addProjectManagerRequest.pmPhoto = '9030';
    addProjectManagerRequest.pmUserID = 'c80d820c-61be-4a2b-9b28-de8589292366';
    addProjectManagerRequest.createdBy = '2022 - 12 - 15 18: 42: 52.1086989';
    addProjectManagerRequest.created = 'some';
    addProjectManagerRequest.lastModified = '2022-12-15 18:42:52.1086989';
    addProjectManagerRequest.lastModifiedBy = 'one';

    /*addProjectManagerRequest.created = '00-00-0000';
    addProjectManagerRequest.createdBy = '00000000-0000-0000-0000-000000000000';
    addProjectManagerRequest.lastModified = '00-00-0000';
    addProjectManagerRequest.lastModifiedBy = '00000000-0000-0000-0000-000000000000';*/
    return this.http.post<ProjectManagerAdd>(this.baseApiUrl + '/api/ProjectManager', addProjectManagerRequest);
  }
  getEmployee(id: string): Observable<ProjectManager> {
    return this.http.get<ProjectManager>(this.baseApiUrl + '/api/ProjectManager/' + id);
  }
  updateEmployee(id: string, updateEmployeeRequest: ProjectManager): Observable<ProjectManager> {
    return this.http.put<ProjectManager>(this.baseApiUrl + '/api/ProjectManager/' + id, updateEmployeeRequest);



  }
  deleteEmployee(id: string): Observable<ProjectManager> {
    return this.http.delete<ProjectManager>(this.baseApiUrl + '/api/ProjectManager/' + id);
  }
  
}
