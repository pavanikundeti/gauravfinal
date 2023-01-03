import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './weather/weather.component';
import { TodoComponent } from './todo/todo.component';
import { PartnersListComponent } from './components/partners/partners-list/partners-list.component';
import { PartnerDetailsComponent } from './components/partners/partner-details/partner-details.component';
import { EditPartnerComponent } from './components/partners/edit-partner/edit-partner.component';
import { AddPartnersComponent } from './components/partners/add-partners/add-partners.component';
import { ReqListComponent } from './components/Requisition/req-list/req-list.component';
import { AddReqComponent } from './components/Requisition/add-req/add-req.component'
import { LoginComponent } from './login/login.component';
import { ForgotpasswordComponent } from './forgotpassword/forgotpassword.component';
import { ResetpasswordComponent } from './resetpassword/resetpassword.component';
import { RolesListComponent } from './components/roles/roles-list/roles-list.component';
import { SkillListComponent } from './skill-list/skill-list.component';
import { AddprojectmanagerComponent } from './components/addprojectmanager/addprojectmanager.component';
import { ProjectmanagerlistComponent } from './components/projectmanagerlist/projectmanagerlist.component';
import { EditprojectmanagerComponent } from './components/editprojectmanager/editprojectmanager.component';
import { ProjectmanagerdetailsComponent } from './components/projectmanagerdetails/projectmanagerdetails.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ReqDetailsComponent } from './components/Requisition/req-details/req-details.component';
import { ProfileComponent } from './components/my-profile/profile/profile.component';
import { RolesPermissionListComponent } from './components/roles/roles-permission-list/roles-permission-list.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent },
{ path: 'forgotpassword', component: ForgotpasswordComponent },
  { path: 'resetpassword', component: ResetpasswordComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'requisitions', component: ReqListComponent },
  { path: 'requisitions/addrequisitions', component:AddReqComponent},
  {path: 'requisitions/details/:requisitionID', component:ReqDetailsComponent},
  { path: 'partner/list', component: PartnersListComponent },
  { path: 'partners/add', component: AddPartnersComponent },
  { path: 'edit/:partnerID', component: EditPartnerComponent },
  { path: 'partnersdetails/:partnerID/edit/:partnerID', component: EditPartnerComponent },
  { path: 'partnersdetails/:partnerID', component: PartnerDetailsComponent },
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'weather', component: FetchDataComponent },
  { path: 'todo', component: TodoComponent},
  //{ path: '', component: ReqListComponent },
  { path: 'login', component: LoginComponent },
{ path: 'forgotpassword', component: ForgotpasswordComponent },
  { path: 'resetpassword', component: ResetpasswordComponent },
  { path: 'partner/list', component: PartnersListComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'roles/list', component: RolesListComponent },
  { path: 'roles/permission/list/:roleId', component: RolesPermissionListComponent },
  { path: 'partners/add', component: AddPartnersComponent },
  { path: 'edit/:partnerID', component: EditPartnerComponent },
  { path: 'partnersdetails/:partnerID/edit/:partnerID', component: EditPartnerComponent },
  { path: 'partnersdetails/:partnerID', component: PartnerDetailsComponent },
  {
    path: 'roleManagement/test/useradministration/role', component: RolesListComponent
  },
  { path: 'skills', component: SkillListComponent },
  { path: 'partnersdetails/:partnerID', component: PartnerDetailsComponent },
  { path: 'projectmanagers', component: ProjectmanagerlistComponent },
  { path: 'projectmanagers/addprojectmanager', component: AddprojectmanagerComponent },
  { path: 'projectmanagers/edit/:projectManagerID', component: EditprojectmanagerComponent },
  { path: 'projectmanagers/projectmanagerdetails/:projectManagerID', component: ProjectmanagerdetailsComponent },
  { path: 'projectmanagers/projectmanagerdetails/:projectManagerID/edit/:projectManagerID', component: EditprojectmanagerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
