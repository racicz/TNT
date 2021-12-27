import { Injectable, Inject } from "@angular/core";
import { Subject } from "rxjs";


@Injectable({
    providedIn: 'root'
})
export class SharedService {
    isAdminVisible: boolean = false;

    adminVisibilityChange: Subject<boolean> = new Subject<boolean>();

    constructor()  {
        this.adminVisibilityChange.subscribe((value) => {
            this.isAdminVisible = value
        });
    }

    toggleSidebarVisibility() {
        this.adminVisibilityChange.next(!this.isAdminVisible);
    }
}