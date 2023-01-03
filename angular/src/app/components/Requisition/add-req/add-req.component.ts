import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AddRequisition } from '../../../models/requisition/addrequisition';
import { ProjectmanagerService } from '../../../services/projectmanager.service';
import { RequisitionService } from '../../../services/requisition.service';
import { RequisitionClient } from '../../../web-api-client';

@Component({
  selector: 'app-add-req',
  templateUrl: './add-req.component.html',
  styleUrls: ['./add-req.component.scss']
})
export class AddReqComponent implements OnInit{
  disabledNumber: number;
  disabledDate: Date;
  Countries: any[];
  ProjectManager: any[];
  selectedPM: string;
  selectedskill: string;
  Skills: any[];
  Departments: any[];
  selectedDepartment: string;
  selectedCurrency: string;
  Currency: any[];
  today: string;
  comments: string;
  selectedMandatory: string;
  selectedExperience: number;


  skillDataArray: any[] = [];

  addRequisitionRequest: AddRequisition = {
    requisitionID: '',
    requisitionCode: '',
    potentialNumber: '',
    complexity: '',
    requisitionDate: new Date,
    deadlineDate: new Date,
    clientName: '',
    clientCountreyID: '',
    projectType: '',
    requisitionStatus: 0,
    expectedStartDate: new Date,
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
    estimatedBudget: 0,
    partnerId: ''
  }
  skilName: string;

  constructor(
    private listsClient: RequisitionClient, private projectmanagerservice: ProjectmanagerService ,private route: ActivatedRoute, private requisitionService: RequisitionService, private router: Router,) { }
  ngOnInit(): void {

    



    const currentDate = new Date();
    this.today = currentDate.toISOString().substring(0, 10);


    this.generateDisabledNumber();
    this.getDisabledDate();
    this.getallcountries();
    this.getProjectManagers();
    this.getskills();
    this.getDepartments();
    this.getAllCurrency();
  }

  generateDisabledNumber() {
    this.disabledNumber = Math.floor(Math.random() * 10000) + Date.now();
  }
  getDisabledDate() {
    this.disabledDate = new Date();
  }
  getallcountries() {
    this.requisitionService.GetAllCountry()
      .subscribe({
        next: (Countriess) => {
          this.Countries = Countriess;
          console.log(Countriess);
        },
        error: (response) => {
          console.log(response);
        }
      });

  }
  getProjectManagers() {
    this.projectmanagerservice.getProjectManagers()
      .subscribe({
        next: (ProjectMan) => {
          this.ProjectManager = ProjectMan;
          console.log(ProjectMan);
        },
        error: (response) => {
          console.log(response);
        }
      });
  }

  getskills() {
    this.requisitionService.getAllSkil()
      .subscribe({
        next: (Skill) => {
          this.Skills = Skill;
          console.log(this.Skills);
        },
        error: (response) => {
          console.log(response);
        }
      });
  }

  getDepartments() {
    this.requisitionService.getAllDepartments()
      .subscribe({
        next: (Department) => {
          this.Departments = Department;
          console.log(this.Departments);
        },
        error: (response) => {
          console.log(response);
        }
      });
  }

  getAllCurrency() {
    this.requisitionService.getAllCurrency()
      .subscribe({
        next: (Curreency) => {
          this.Currency = Curreency;
          console.log(this.Currency);
        },
        error: (response) => {
          console.log(response);
        }
      });
  }
  addRequisition() {
    this.requisitionService.addRequisition(this.addRequisitionRequest)
      .subscribe({
        next: (requisition) => {
          console.log(requisition);
        }
      })
  }
  onSubmit() {
    let splitone: string[] = [];
    let dropdown = this.selectedskill
    splitone = dropdown.split('_')
    let desired: string = splitone[1];

    let split2: string[] = [];
    let dropdown2 = this.selectedMandatory
    split2 = dropdown2.split('_');
    let desired2: string = split2[1];

    console.log(desired);
    this.skillDataArray.push({
      dropdown: desired,
      dropdown2: desired2,
      dropdown3: this.selectedExperience,
      Comments: this.comments,
    });
    console.log(this.skillDataArray);

  }
}

