import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProjectManager } from '../../models/projectmanager.model';
import { ProjectmanagerService } from '../../services/projectmanager.service';
@Component({
  selector: 'app-projectmanagerdetails',
  templateUrl: './projectmanagerdetails.component.html',
  styleUrls: ['./projectmanagerdetails.component.scss']
})
export class ProjectmanagerdetailsComponent implements OnInit {
  message: string = "Are you sure want to delete?"

  confirmButtonText = "Yes"

  cancelButtonText = "Cancel"
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
  /*public openConfirmationDialog() {

    this.confirmationDialogService.confirm('Please confirm..', 'Do you really want to ... ?')

      .then((confirmed) => console.log('User confirmed:', confirmed))

      .catch(() => console.log('User dismissed the dialog (e.g., by using ESC, clicking the cross icon, or clicking outside the dialog)'));

  }*/


  deleteEmployee(id: string) {
    if(confirm('Are You Sure to Delete Record?'))
    this.projectmanagerService.deleteEmployee(id).subscribe({
      next: (response) => {
        this.router.navigate([''])
      }
    });
  }




}
