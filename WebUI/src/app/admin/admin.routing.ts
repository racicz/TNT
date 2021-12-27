import { Routes } from "@angular/router";
import { LoginComponent } from "../site/login/login.component";
import { RegistrationComponent } from "./registration/registration.component";

export const AdminRoutes: Routes = [
    {
      path: '',
      children: [
        {
          path: '',
          component: RegistrationComponent
        }
      ]
    }
  ];
  