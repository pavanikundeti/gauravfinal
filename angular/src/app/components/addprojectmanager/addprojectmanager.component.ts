import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectManagerAdd } from '../../models/projectmanageradd.model';
import { ProjectmanagerService } from '../../services/projectmanager.service';

@Component({
  selector: 'app-addprojectmanager',
  templateUrl: './addprojectmanager.component.html',
  styleUrls: ['./addprojectmanager.component.scss']
})
export class AddprojectmanagerComponent implements OnInit{
  addProjectManagerRequest: ProjectManagerAdd = {
    projectManagerID: '',
    projectManagerName: '',
    employeeID: '',
    joiningDate: '',
    pmEmailID: '',
    pmPhoneNumber: '',
    pmPhoto: '',
    pmStatus: 0,
    pmUserID: '',
    createdBy: '',
    created: '',
    lastModified: '',
    lastModifiedBy: ''



  };
  constructor(private projectmanagerService: ProjectmanagerService, private router: Router) { }
  ngOnInit(): void {



    //throw new Error('Method not implemented.');
  }



  addEmployee() {
    this.projectmanagerService.addEmployee(this.addProjectManagerRequest)
      .subscribe({
        next: (projectmanagers) => {
          console.log(projectmanagers);
          this.router.navigate(['']);
        }



      });
    console.log(this.addProjectManagerRequest);
  }


}
