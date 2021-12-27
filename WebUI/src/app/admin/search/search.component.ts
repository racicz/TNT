import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
];

export interface Customer {
  orderNumber: number;
  name: string;
  amountDue: number;
}

const CUST_DATA: Customer[] = [
  {orderNumber: 100, name: 'Milan Bajic', amountDue: 250.00},
  {orderNumber: 200, name: 'Stoja Ristic', amountDue: 150.00},
  {orderNumber: 300, name: 'Tanja Savic', amountDue: 75.00},
];

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent implements OnInit {

  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  dataSource = ELEMENT_DATA;

  custColumns: string[] = ['orderNumber', 'name', 'amountDue', 'actions'];
  custDataSource = CUST_DATA;
  clickedRows = new Set<Customer>();

  constructor(private sharedService: SharedService) { 
    this.sharedService.adminVisibilityChange.next(true);
  }

  ngOnInit(): void {
  }

  onOrderSelected(row:Customer){
    this.clickedRows.clear();
    this.clickedRows.add(row);
  }

}
