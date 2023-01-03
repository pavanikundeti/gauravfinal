import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProjectManager } from '../../models/projectmanager.model';
import { ProjectmanagerService } from '../../services/projectmanager.service';

@Component({
  selector: 'app-editprojectmanager',
  templateUrl: './editprojectmanager.component.html',
  styleUrls: ['./editprojectmanager.component.scss']
})
export class EditprojectmanagerComponent implements OnInit {
  employeeDetails: ProjectManager = {
    projectManagerID: '',
    projectManagerName: '',
    employeeID: '',
    joiningDate: '',
    pmEmailID: '',
    pmPhoneNumber: '',
    pmPhoto: '',
    pmStatus: 0,
    pmUserID: ''

  }
  constructor(private router: Router, private route: ActivatedRoute, private projectmanagerService: ProjectmanagerService) { }
  ngOnInit(): void {
    this.route.paramMap.subscribe({



      next: (params) => {
        const id = params.get('projectManagerID');
        if (id) {
          //call api
          this.projectmanagerService.getEmployee(id).subscribe({
            next: (response) => {
              this.employeeDetails = response;
            }
          })
        }
      }
    })
    //throw new Error('Method not implemented.');
  }
  updateEmployee() {
    this.projectmanagerService.updateEmployee(this.employeeDetails.projectManagerID, this.employeeDetails).
      subscribe({
        next: (response) => {
          console.log(response);
          this.router.navigate([''])
        }
      });
  }




}

