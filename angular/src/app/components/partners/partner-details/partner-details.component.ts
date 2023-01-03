import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Partner } from '../../../models/partner.model';
import { PartnersService } from '../../../services/partners.service';

@Component({
  selector: 'app-partner-details',
  templateUrl: './partner-details.component.html',
  styleUrls: ['./partner-details.component.css']
})
export class PartnerDetailsComponent implements OnInit {
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
  constructor(private route: ActivatedRoute, private partnerService: PartnersService, private router:Router) { }
    ngOnInit(): void {
      /*throw new Error('Method not implemented.');*/
      this.route.paramMap.subscribe({
        next: (params) => {
          const id = params.get('partnerID');
          if (id) {
            this.partnerService.getPartnerDetails(id).subscribe({
              next: (response) => {
                this.partnerDetails = response;
              }
              })
          }
        }
        })
  }
  deletePartner(id: string) {
    this.partnerService.deletePartner(id).subscribe({
      next: (response) => {
        this.router.navigate(['']);
      }
    })
  }

}
