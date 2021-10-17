import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { PeopleList } from './components/PeopleList/people-list.component';
import { OrganizationsList } from './components/OrganizationsList/organizations-list.component';
import { PersonCreateComponents } from './components/Person/person-create/person-create.component';
import { PersonProfileComponents } from './components/Person/person-profile/person-profile.component';
import { PersonEditComponents } from './components/Person/person-edit/person-edit.component';
import { OrganizationCreateComponent } from './components/Organization/organization-create/organization-create.component';
import { OrganizationEditComponent } from './components/Organization/organization-edit/organization-edit.component';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PeopleList,
    OrganizationsList,
    PersonCreateComponents,
    PersonProfileComponents,
    PersonEditComponents,
    OrganizationCreateComponent,
    OrganizationEditComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'people', component: PeopleList, pathMatch: 'full' },
      { path: 'organizations', component: OrganizationsList, pathMatch: 'full' },
      { path: 'organizations/create', component: OrganizationCreateComponent, pathMatch: 'full' },
      { path: 'organizations/edit/:id', component: OrganizationEditComponent, pathMatch: 'full' },
      { path: 'people/create', component: PersonCreateComponents, pathMatch: 'full' },
      { path: 'people/edit/:id', component: PersonEditComponents, pathMatch: 'full' },
      { path: 'people/:id', component: PersonProfileComponents, pathMatch: 'full' },
    ])
  ],
  providers: [ ],
  bootstrap: [AppComponent]
})
export class AppModule { }
