import { Component, OnInit } from '@angular/core';
import { NgxPaginationModule } from 'ngx-pagination';
import { ProjectManager } from 'src/app/models/projectmanager.model';
import { ProjectmanagerService } from '../../services/projectmanager.service';

@Component({
  selector: 'app-projectmanagerlist',
  templateUrl: './projectmanagerlist.component.html',
  styleUrls: ['./projectmanagerlist.component.scss'],
  
 
})
export class ProjectmanagerlistComponent implements OnInit {
  isDesc: boolean = false;
  column: string = 'employeeID';
  searchText: any;
  projectmanagers: ProjectManager[] = [];
  constructor(private projectmanagerService: ProjectmanagerService) { }
  ngOnInit(): void {
    this.projectmanagerService.getProjectManagers()
      .subscribe({
        next: (projectmanagers) => {
          this.projectmanagers = projectmanagers;
          console.log(projectmanagers);
        },
        error: (response) => {
          console.log(response);
        }
      })
  }


  
  sort(property) {
    this.isDesc = !this.isDesc; //change the direction    
    this.column = property;
    let direction = this.isDesc ? 1 : -1;

    this.projectmanagers.sort(function (a, b) {
      if (a[property] < b[property]) {
        return -1 * direction;
      }
      else if (a[property] > b[property]) {
        return 1 * direction;
      }
      else {
        return 0;
      }
    });
  };


 
  

  


  


}
