import { Component } from '@angular/core';
import { RolesService } from '../../../services/roles.service';

@Component({
  selector: 'app-roles-list',
  templateUrl: './roles-list.component.html',
  styleUrls: ['./roles-list.component.css']
})
export class RolesListComponent {
  validator: any = {
    name: "",
    desc: ""
  }
    ;
  roleIdToBeDeleted: string = "";
  idForPermissionCreation: string = "";
  functionalities: any[] = [];
  roles: any = [];
  addR: any = {
    name: "",
    normalizedName: ""
  };
  edit: any = {};
  constructor(private dataService: RolesService) { }

  ngOnInit(): void {
    this.dataService.getAllRoles()
      .subscribe(
        {
          next: (role) => {
            this.roles = role;
            for (let i = 0; i < this.roles.length; i++) {
              this.roles[i].description="Hardcoded Description."
            }
            console.log(role);
          },
          error: (response) => { console.log(response) }
        }
      );
  }
  addRole(): void {
    this.nameValidator();
    this.descValidator();
    console.log(this.addR);
    if (this.validator.name == "" && this.validator.desc == "") {
      this.dataService.addRole(this.addR).subscribe({
        next: (user) => {
          console.log(user);
          this.idForPermissionCreation = user.id;
          this.addDefaultPermissions();
          setInterval(this.refresh, 2000);
        }
      });
    }
  }
  refresh() {
    window.location.reload();
  }
  addDefaultPermissions() {
    console.log("adding default!");
    this.dataService.getAllFunctionalities().subscribe({
      next: (user) => {
        console.log(user);
        this.functionalities = user;
        console.log(this.functionalities);
        for (let index = 0; index < this.functionalities.length; index++) {
          this.dataService.addPermission({
            id: this.idForPermissionCreation,
            fid: this.functionalities[index].fId
          }).subscribe({
            next: (permission) => {
              console.log("success");
            }
          });
        }
        setInterval(this.refresh, 2000);
      }
    });

  }
  deleteRole(id: string): void {
    console.log(id);
    this.dataService.deleteRole(id).subscribe({
      next: (user) => {
        console.log(user);
        this.removePermissions(id);
        setInterval(this.refresh, 2000);
      }
    });
  }
  removePermissions(id: string) {
    console.log(id);
    this.dataService.deletePermission(id).subscribe({
      next: (permission) => {
        console.log("success");
      }
    });
  }
  editRole(name: string, description: string, id: string): void {
    this.edit.name = name;
    this.edit.description = description;
    this.roleIdToBeDeleted = id;
    console.log(this.edit);
  }
  updateUser(): void {
    this.nameEditValidator();
    this.descEditValidator();
    console.log(this.edit);
    console.log(this.validator);
    if (this.validator.name == "" && this.validator.desc == "") {
      this.dataService.updateRole(this.edit, this.roleIdToBeDeleted).subscribe({
        next: (user) => {
          console.log(user);
          window.location.reload();
        }
      });
    }
  }

  nameValidator() {
    console.log(this.addR);
    if (this.addR.name == "") {
      this.validator.name = "Name field can not be empty";
    }
    else {
      this.validator.name = "";
    }
  }
  descValidator() {
    if (this.addR.normalizedName == '') {
      this.validator.desc = "Description can't be empty";
    }
    else {
      this.validator.desc = '';
    }
  }

  nameEditValidator() {
    console.log(this.edit);
    if (this.edit.name == "") {
      this.validator.name = "Name field can not be empty";
    }
    else {
      this.validator.name = "";
    }
  }
  descEditValidator() {
    if (this.edit.description == '') {
      this.validator.desc = "Description can't be empty";
    }
    else {
      this.validator.desc = '';
    }
  }

}
