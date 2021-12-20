import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SearchComponent } from './admin/search/search.component';
import { HomeComponent } from './site/home/home.component';
import { LoginComponent } from './site/login/login.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'login',
    component: LoginComponent,
    loadChildren: () => import('./site/login/login.module').then(m => m.LoginModule)
  },
  {
    path: 'admin/search',
    component: SearchComponent,
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
