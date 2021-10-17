import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { OrganizationService } from '../../../services/organization.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'organization-edit',
  templateUrl: './organization-edit.component.html',
  styleUrls: ['./organization-edit.component.css']
})
export class OrganizationEditComponent {

  organization$: Observable<any>
  organizationForm: FormGroup

  constructor(private route: ActivatedRoute, private fb: FormBuilder, private organizationService: OrganizationService) {
    this.route.params.subscribe(params => {
      const id = params['id'];

      this.organization$ = this.organizationService.getById(id);


      this.organization$.subscribe({
        next: o => {
          this.organizationForm = this.fb.group({
            id: [o.Id, Validators.required],
            name: [o.Name, Validators.required],
            address: [o.Address, Validators.required],
            activitie: [o.Activitie, Validators.required]
          })
        }
      })

    })
  }

  edit() {
    if (this.organizationForm.valid) {
      this.organizationService.update(this.organizationForm.value).subscribe({
        next: (n) => { console.log(n) },
        error: (e) => { console.log(e) },
        complete: () => { alert("edited  organization!") }
      })
    }
    else {
      alert("Something went wrong!")
    }
  }
}
