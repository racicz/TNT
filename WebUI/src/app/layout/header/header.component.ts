import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit {
  isAdminVisible: boolean = false;

  constructor(private sharedService: SharedService) { 
    sharedService.adminVisibilityChange.subscribe(t=>{this.isAdminVisible = t});
  }

  ngOnInit(): void {
  }

}
