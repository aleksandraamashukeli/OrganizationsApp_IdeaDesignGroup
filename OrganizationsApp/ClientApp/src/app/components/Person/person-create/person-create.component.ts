import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GenderType } from '../../../services/models/GenderType';
import { CityType } from '../../../services/models/CityType';
import { PersonService } from '../../../services/person.service';

@Component({
  selector: 'person-create',
  templateUrl: './person-create.component.html',
  styleUrls: ['./person-create.component.css']
})
export class PersonCreateComponents {

  personForm: FormGroup;
  genders = GenderType;
  citys = CityType;

  errorMsg;

  constructor(private fb: FormBuilder, private personService: PersonService) {
    this.personForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      phoneNumber: [null, Validators.required],
      personalId: [null, Validators.required],
      gender: [null, Validators.required],
      city: [null, Validators.required],
      birthday: [null, Validators.required]
    })
  }

  create() {
    if (this.personForm.valid) {
      this.personForm.controls["city"].setValue(parseInt(this.personForm.controls["city"].value))
      this.personForm.controls["gender"].setValue(parseInt(this.personForm.controls["gender"].value))
      this.personForm.controls["phoneNumber"].setValue(parseInt(this.personForm.controls["phoneNumber"].value))

      this.personService.create(this.personForm.value).subscribe({
        next: (n) => { console.log(n) },
        error: (e) => { this.errorMsg = "ops! error" },
        complete: () => { alert("added new person!") }
      })
    }
    else {
      alert("Something went wrong!")
    }
  }

}
