import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Requisition } from 'src/app/models/requisition/req-list.model';
import { RequisitionService } from 'src/app/services/requisition.service';

@Component({
  selector: 'app-req-details',
  templateUrl: './req-details.component.html',
  styleUrls: ['./req-details.component.scss']
})
export class ReqDetailsComponent {
  requisitionDetails: Requisition =
  {
    requisitionID: '',
    requisitionCode: '',
    potentialNumber: '',
    complexity: '',
    requisitionDate: new Date(),
    deadlineDate: new Date(),
    clientName: '',
    clientCountreyID: '',
    projectType: '',
    requisitionStatus: 0,
    expectedStartDate: new Date(),
    budget: 0,
    departmentID: '',
    currencyID: '',
    projectDescription: '',
    jobDescription: '',
    duration: 0,
    durationUnits: '',
    shiftTimings: '',
    noOfResources: 0,
    openPositions: 0,
    keyDescription: '',
    preferredEducation: '',
    minExperience: 0,
    MaxExperience: 0,
    jdFileName: '',
    skillID: '',
    mandatory: 0,
    experience: 0,
    comments: '',
    estimatedBudget:0,
    partnerId: ''     
  }
  constructor(private route: ActivatedRoute, private requisitionService: RequisitionService, private router:Router) { }
  ngOnInit(): void {
    /*throw new Error('Method not implemented.');*/
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('requisitionID');
        if (id) {
          this.requisitionService.getRequisitionDetails(id).subscribe({
            next: (response) => {
              this.requisitionDetails = response;
              console.log(this.requisitionDetails)
            }
            })
        }
      }
      })
}

}
