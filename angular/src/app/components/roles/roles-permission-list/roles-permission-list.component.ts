import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RolesService } from '../../../services/roles.service';

@Component({
  selector: 'app-roles-permission-list',
  templateUrl: './roles-permission-list.component.html',
  styleUrls: ['./roles-permission-list.component.css']
})
export class RolesPermissionListComponent {
  permissions: any;
  functions: any[] = [];
  id: any = "5bda1df0-4aa5-411c-3768-08dae1779037";
  constructor(private dataService: RolesService, private route: ActivatedRoute) { }
  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const roleIdFromRoute = String(routeParams.get('roleId'));
    this.id = roleIdFromRoute;
    console.log(this.id);
    this.dataService.getPermissionsByRoleId(roleIdFromRoute)
      .subscribe(
        {
          next: (user) => {
            this.permissions = user;
            console.log(user);
            for (let i = 0; i < this.permissions.length; i++) {
              this.dataService.getFunctionality(this.permissions[i].fId).subscribe(
                {
                  next: (user) => {
                    this.functions[i] = user; 
                  },
                  error: (response) => { console.log(response) }
                }
                )
            }
          },
          error: (response) => { console.log(response) }
        }
      );
  }
  changeRole(): void {
    console.log("first");
    // this.id=document.getElementById("role")?.;
    console.log(this.id);
    this.dataService.getPermissionsByRoleId(this.id)
      .subscribe(
        {
          next: (user) => {
            this.permissions = user;
            console.log(user);
          },
          error: (response) => { console.log(response) }
        }
      );
  }
  updatePermission(index: number): void {
    console.log(this.permissions);
    console.log(index);
    this.dataService.updatePermission({
      pId: this.permissions[index].pId,
      id: this.permissions[index].id,
      fId: this.permissions[index].fId,
      view: this.permissions[index].view,
      add: this.permissions[index].add,
      edit: this.permissions[index].edit,
      delete: this.permissions[index].delete
      }).subscribe(
      {
        next: (user) => {
        },
        error: (response) => { console.log(response) }
      }
    )

  }
}
