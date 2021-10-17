import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PersonService } from '../../../services/person.service';
import { Observable } from 'rxjs';
import { CityType } from '../../../services/models/CityType';
import { GenderType } from '../../../services/models/GenderType';
import { OrganizationService } from '../../../services/organization.service';

@Component({
  selector: 'person-profile',
  templateUrl: './person-profile.component.html',
  styleUrls: ['./person-profile.component.css']
})
export class PersonProfileComponents {

  person$: Observable<any>;
  person: any;


  organizations$: Observable<any>;
  organizations: any;

  cities = CityType;
  genders = GenderType;


  constructor(private route: ActivatedRoute, private personService: PersonService, private organizationService: OrganizationService) {
    this.route.params.subscribe(params => {
      const id = params['id'];
      this.person$ = this.personService.getById(id);
      this.person$.subscribe({
        next: p => { this.person =p }
      })

      this.organizations$ = this.organizationService.getPersonOrganizations(id);
      this.organizations$.subscribe({
        next: o => { this.organizations = o }
      })
    })
  }

  delete(id) {
    console.log(id);
    this.personService.delete(id).subscribe({
      next: v => alert("person deleted"),
      error: e => console.log(e),
      complete: () => window.location.href= '/people'
    })
  }

}
