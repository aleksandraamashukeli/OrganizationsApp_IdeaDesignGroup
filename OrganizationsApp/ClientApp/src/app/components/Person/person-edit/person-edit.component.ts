import { Component } from '@angular/core';
import { FormGroup,FormBuilder, Validators } from '@angular/forms';
import { GenderType } from '../../../services/models/GenderType';
import { CityType } from '../../../services/models/CityType';
import { PersonService } from '../../../services/person.service';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'person-edit',
  templateUrl: './person-edit.component.html',
  styleUrls: ['./person-edit.component.css']
})
export class PersonEditComponents {
  personForm: FormGroup;
  genders = GenderType;
  citys = CityType;

  person$: Observable<any>

  errorMsg;

  constructor(private route: ActivatedRoute, private fb: FormBuilder, private personService: PersonService) {

    this.route.params.subscribe(params => {
      const id = params['id'];
      this.person$ = this.personService.getById(id);
      this.person$.subscribe({
        next: (p) => {
          console.log(p)
          this.personForm = this.fb.group({
            id: [p.Id, Validators.required],
            firstName: [p.FirstName, Validators.required],
            lastName: [p.LastName, Validators.required],
            phoneNumber: [p.PhoneNumber, Validators.required],
            personalId: [p.PersonalId, Validators.required],
            gender: [p.Gender, Validators.required],
            city: [p.City, Validators.required],
            birthday: [p.BirthDay.split('T')[0], Validators.required]
          })
        }
      })
    })


  }

  edit() {

    console.log(this.personForm.value);
    if (this.personForm.valid) {
      this.personForm.controls["city"].setValue(parseInt(this.personForm.controls["city"].value))
      this.personForm.controls["gender"].setValue(parseInt(this.personForm.controls["gender"].value))

      this.personService.update(this.personForm.value).subscribe({
        next: (n) => { console.log(n) },
        error: (e) => { this.errorMsg = "ups! error" },
        complete: () => { alert("person updated!") }
      })
    }
    else {
      alert("Something went wrong!")
    }
  }
}
