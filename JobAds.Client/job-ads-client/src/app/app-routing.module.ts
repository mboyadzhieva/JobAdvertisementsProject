import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateAdvertisementComponent } from './create-advertisement/create-advertisement.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './services/auth-guard.service';
import { ListAdvertisementsComponent } from './list-advertisements/list-advertisements.component';
import { DetailsAdvertisementComponent } from './details-advertisement/details-advertisement.component';
import { EditAdvertisementComponent } from './edit-advertisement/edit-advertisement.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'create',
    component: CreateAdvertisementComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'advertisements',
    component: ListAdvertisementsComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'advertisements/:id',
    component: DetailsAdvertisementComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'advertisements/:id/edit',
    component: EditAdvertisementComponent,
    canActivate: [AuthGuardService],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
