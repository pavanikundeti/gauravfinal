import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Requisition } from 'src/app/models/requisition/req-list.model';
import { RequisitionService } from 'src/app/services/requisition.service';
import { RequisitionClient, RequisitionDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-req-list',
  templateUrl: './req-list.component.html',
  styleUrls: ['./req-list.component.scss']
})
export class ReqListComponent implements OnInit{
  requisitionDetails: Requisition;
  lists: RequisitionDto[];

  selectedList: RequisitionDto;
  constructor(
    private listsClient: RequisitionClient, private route: ActivatedRoute, private partnerService: RequisitionService, private router: Router) { }

  ngOnInit(): void {
    this.listsClient.get().subscribe(
      result => {
        this.lists = result.lists;
        console.log(this.lists);
        if (this.lists.length) {
          this.selectedList = this.lists[0];
        }
      },
      error => console.error(error)
    );

  }
}
