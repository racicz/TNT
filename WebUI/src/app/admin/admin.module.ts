import { NgModule } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from '../app-routing.module';
import { SearchComponent } from './search/search.component';



@NgModule({
  declarations: [
    SearchComponent
  ],
  imports: [
   MatTabsModule,
   MatTableModule
  ],
  providers: [],
  bootstrap: [SearchComponent]
})
export class AdminModule { }
