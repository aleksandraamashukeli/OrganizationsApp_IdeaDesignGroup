import { Component } from '@angular/core';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'people-list',
  templateUrl: './people-list.component.html',
  styleUrls: ['./people-list.component.css']
})
export class PeopleList {

  $people: Promise<any>;
  people: Array<any>;

  pageNumber: number = 1;

  personCount;

  searchString;

  constructor(private personService: PersonService) {

    this.getCount();

    this.$people = this.getPeople();

    this.$people.then(p => {this.people = p });
  }

  counter(count: number) {
    var array = [];
    for (var i = 1; i <= count; i++) {
      array.push(i);
    }
    return array;
  }
  changePage(page) {
    this.pageNumber = page;
    this.getPeople().then(p => { this.people = p });
  }

  getCount() {
    this.personService.getCount().subscribe({
      next: c => this.personCount = c
    })
  }

  search() {
    this.personService.get(this.pageNumber, this.searchString).subscribe({
      next: o => this.people = o
    })
  }
  async getPeople() {
    return this.personService.get(this.pageNumber,"").toPromise();
  }

}
