import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { SearchComponent } from './search/search.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatIconModule } from '@angular/material/icon';


@NgModule({
  declarations: [
    SearchComponent
  ],
  imports: [
   MatTabsModule,
   MatTableModule,
   MatFormFieldModule,
   MatInputModule,
   MatSelectModule,
   MatDatepickerModule,
   MatIconModule
  ],
  providers: [],
  bootstrap: [SearchComponent]
})
export class AdminModule { }
