import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { SearchComponent } from './search/search.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatIconModule } from '@angular/material/icon';
import { RegistrationComponent } from './registration/registration.component';
import { AdminRoutes } from './admin.routing';
import { RouterModule } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    SearchComponent,
    RegistrationComponent
  ],
  imports: [
   ReactiveFormsModule,
   CommonModule,
   MatTabsModule,
   MatTableModule,
   MatFormFieldModule,
   MatInputModule,
   MatSelectModule,
   MatDatepickerModule,
   MatIconModule,
   MatProgressSpinnerModule,
   RouterModule.forChild(AdminRoutes)
  ],
  providers: [AuthenticationService],
  bootstrap: [SearchComponent]
})
export class AdminModule { }
