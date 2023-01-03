import { Component, OnInit } from '@angular/core';
import { Partner } from '../../../models/partner.model';
import { PartnersService } from '../../../services/partners.service';

@Component({
  selector: 'app-partners-list',
  templateUrl: './partners-list.component.html',
  styleUrls: ['./partners-list.component.css']
})
export class PartnersListComponent implements OnInit {

  searchText: any;
  partners: Partner[] = [];
  constructor(private partnersService: PartnersService) { }
  ngOnInit(): void {


    this.partnersService.getAllPartners()
      .subscribe({
        next: (partners) => {
          this.partners = partners;
          console.log(partners);
        },
        error: (response) => {
          console.log(response);
        }
      })


  }
}
