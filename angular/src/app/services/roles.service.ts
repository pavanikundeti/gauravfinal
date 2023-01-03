import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
@Injectable({
  providedIn: 'root'
})
export class RolesService {
  baseApiUrl: string = "https://localhost:7184";
  constructor(private http: HttpClient, private toastr: ToastrService) { }

  getAllUsers(): Observable<any[]> {
    return this.http.get<any[]>(this.baseApiUrl + '/api/User');
  }
  getAllFunctionalities(): Observable<any[]> {
    return this.http.get<any[]>(this.baseApiUrl + '/api/Functionality');
  }

  getUser(id: string): Observable<any[]> {
    return this.http.get<any[]>(this.baseApiUrl + '/api/User/' + id);
  }
  getFunctionality(id: string): Observable<any[]> {
    return this.http.get<any[]>(this.baseApiUrl + '/api/Functionality/' + id);
  }
  updateUser(updateEmployeeRequest: any): Observable<any> {
    console.log(updateEmployeeRequest);
    return this.http.put<any>(this.baseApiUrl + '/api/User/' + "4064537c-57d0-45e0-963c-d91b07ee32b1", updateEmployeeRequest);
  }

  getAllRoles(): Observable<any[]> {
    return this.http.get<any[]>(this.baseApiUrl + '/api/Roles');
  }
  addRole(updateEmployeeRequest: any): Observable<any> {
    console.log(updateEmployeeRequest);
    return this.http.post<any>(this.baseApiUrl + '/api/Roles/', updateEmployeeRequest);
  }

  deleteRole(id: string): Observable<any> {
    return this.http.delete<any>(this.baseApiUrl + '/api/Roles/' + id);
  }

  getPermissionsByRoleId(id: string): Observable<any[]> {
    return this.http.get<any[]>(this.baseApiUrl + '/api/RolePermission/' + id);
  }

  updatePermission(updateEmployeeRequest: any): Observable<any> {
    console.log(updateEmployeeRequest);
     console.log(updateEmployeeRequest.pId);
    return this.http.put<any>(this.baseApiUrl + '/api/RolePermission/' + updateEmployeeRequest.pId, updateEmployeeRequest);
  }

  addPermission(updateEmployeeRequest: any): Observable<any> {
    console.log(updateEmployeeRequest);
    // console.log(updateEmployeeRequest[0].pId);
    return this.http.post<any>(this.baseApiUrl + '/api/RolePermission/', updateEmployeeRequest  );
  }
  deletePermission(id: string): Observable<any> {
    return this.http.delete<any>(this.baseApiUrl + '/api/RolePermission/' + id);
  }

  updateRole(updateEmployeeRequest: any, id: string): Observable<any> {
    updateEmployeeRequest.id = id;
    console.log(updateEmployeeRequest);
    return this.http.put<any>(this.baseApiUrl + '/api/Roles/' + id, { id: updateEmployeeRequest.id, name: updateEmployeeRequest.name, normalizedName: updateEmployeeRequest.description });
  }

  showSuccess(message: any, title: any) {
    this.toastr.success(message, title)
  }

  showError(message: any, title: any) {
    this.toastr.error(message, title)
  }

  showInfo(message: any, title: any) {
    this.toastr.info(message, title)
  }

  showWarning(message: any, title: any) {
    this.toastr.warning(message, title)
  }
}
