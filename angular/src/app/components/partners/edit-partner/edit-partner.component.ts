import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Partner } from '../../../models/partner.model';
import { PartnersService } from '../../../services/partners.service';

@Component({
  selector: 'app-edit-partner',
  templateUrl: './edit-partner.component.html',
  styleUrls: ['./edit-partner.component.css']
})
export class EditPartnerComponent implements OnInit{

  partnerDetails: Partner = {
    partnerID: '',
    partnerName: '',
    location: '',
    countryID: '',
    registeredDate: '',
    spocUserID: '',
    address1: '',
    billingAddress1: '',
    partnerImage: '',
    partnerStatus: 0,
    createdBy: '',
    created: '',
    lastModifiedBy: '',
    lastModified: ''
    }
  constructor(private route: ActivatedRoute, private partnerService: PartnersService, private router: Router) { }
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
       const id= params.get(' partnerID');
        if (id) {
          this.partnerService.getPartnerDetails(id)
            .subscribe({
              next: (response) => {
                this.partnerDetails = response;
              }
              })
        }
      }
      })
  }
 //updatePartner() {
 //   this.partnerService.updatePartner(this.partnerDetails.partnerID, this.partnerDetails)
 //   .subscribe({
 //     next: (response) => {
 //       this.router.navigate(['']);
 //     }
 //     })
 // }
  deletePartner(id:string) {
    this.partnerService.deletePartner(id)
      .subscribe({
        next: (response) => {
          this.router.navigate(['partner']);
        }
        })
  }

}
