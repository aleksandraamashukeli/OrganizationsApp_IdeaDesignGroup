import { Component } from '@angular/core';
import { OrganizationService } from '../../../services/organization.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'organization-create',
  templateUrl: './organization-create.component.html',
  styleUrls: ['./organization-create.component.css']
})
export class OrganizationCreateComponent {

  organizationForm: FormGroup

  constructor(private organizationService: OrganizationService, private fb: FormBuilder) {
    this.organizationForm =  this.fb.group({
      name: ['', Validators.required],
      address: ['', Validators.required],
      activitie: ["", Validators.required]
    })
  }

  create() {
    if (this.organizationForm.valid) {

      this.organizationService.create(this.organizationForm.value).subscribe({
        next: (n) => { console.log(n) },
        error: (e) => { console.log(e) },
        complete: () => { alert("added new organization!") }
      })
    }
    else {
      alert("Something went wrong!")
    }
  }
}
