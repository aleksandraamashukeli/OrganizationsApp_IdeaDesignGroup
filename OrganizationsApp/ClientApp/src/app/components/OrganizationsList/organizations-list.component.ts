import { Component } from '@angular/core';
import { OrganizationService } from '../../services/organization.service';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'organizations-list',
  templateUrl: './organizations-list.component.html',
  styleUrls: ['./organizations-list.component.css']
})
export class OrganizationsList {
  $organizations: Promise<any>;
  organizations: Array<any>;

  $organizationPeople: Promise<any>;
  organizationPeople: Array<any>;
  selectedPerson = { Id: null };

  peoplePanelIsOpen:boolean= false;

  selectedOrganization;
  selectedOrganizationName;

  pageNumber: number = 1;

  organizationCount;

  searchString;

  constructor(private organizationService: OrganizationService, private personService: PersonService) {


    this.getCount();

    this.$organizations = this.getOrganizations();

    this.$organizations.then(o => this.organizations = o);
  }

  async getOrganizations() {
    return this.organizationService.get(this.pageNumber,"").toPromise();
  }


  counter(count: number) {
    var array = [];
    for (var i = 1; i <= count; i++) {
      array.push(i);
    }
    return array;
  }

  search() {
    this.organizationService.get(this.pageNumber, this.searchString).subscribe({
      next: o => this.organizations = o
    })
  }

  getCount() {
    this.organizationService.getCount().subscribe({
      next: c => this.organizationCount = c
    })
  }

  changePage(page) {
    this.pageNumber = page;
    this.getOrganizations().then(o => { this.organizations = o});
  }

  OpenPeoplePanel(id, name) {
    this.selectedOrganization = id;
    this.selectedOrganizationName = name;
    this.$organizationPeople = this.personService.getForOrganization(id).toPromise();
    this.$organizationPeople.then(p => { this.organizationPeople = p });

    this.peoplePanelIsOpen = true;

  }

  select(id) {
    this.selectedPerson = this.organizationPeople.filter(p => p.Id == id)[0];
  }

  addPersonToOrganization() {
    if (this.selectedPerson.Id != null) {

      var value = {
        organizationId: this.selectedOrganization,
        personId: this.selectedPerson.Id
      }
      this.organizationService.addPersonToOrganization(value).subscribe({
        next: (n) => { console.log(n) },
        error: (e) => {alert("error") },
        complete: () => { alert("added new person!"); window.location.reload() }
      });
    }
  }

  delete(id) {
    this.organizationService.delete(id).subscribe({
      error: e => console.log(e),
      complete: () => window.location.href = '/organizations'
    })
  }
}
