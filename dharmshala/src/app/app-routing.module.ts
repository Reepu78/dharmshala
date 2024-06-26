import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SigninComponent } from './admin/signin/signin/signin.component';
import { DashboardComponent } from './admin/dashboard/dashboard/dashboard.component';
import { AboutComponent } from './admin/about/about/about.component';
import { MemberComponent } from './admin/member/member/member.component';
import { ProjectsComponent } from './admin/project/projects/projects.component';
import { GalleryComponent } from './admin/gallery/gallery/gallery.component';
import { SocialmediaComponent } from './admin/social media/socialmedia/socialmedia.component';
import { FacilityComponent } from './admin/facility/facility/facility.component';
import { MemberformComponent } from './admin/member form/memberform/memberform.component';
import { FacilityformComponent } from './admin/facility form/facilityform/facilityform.component';
import { UploadimageComponent } from './admin/uploadimage/uploadimage.component';
import { AddprojectsComponent } from './admin/addprojects/addprojects.component';
import { MembereditformComponent } from './admin/member form/membereditform/membereditform.component';
import { SocialmediaformComponent } from './admin/social media/socialmediaform/socialmediaform.component';
import { AuthGuard } from './guard/auth.guard';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent,canActivate: [AuthGuard] },
  { path: 'about', component: AboutComponent,canActivate: [AuthGuard] },
  { path: 'member', component: MemberComponent,canActivate: [AuthGuard] },
  { path: 'projects', component: ProjectsComponent,canActivate: [AuthGuard] },
  { path: 'gallery', component: GalleryComponent,canActivate: [AuthGuard] },
  { path: 'member-form', component: MemberformComponent,canActivate: [AuthGuard]},
  { path: 'member-edit', component: MembereditformComponent,canActivate: [AuthGuard]},
  { path: 'facility-form', component: FacilityformComponent,canActivate: [AuthGuard]},
  { path: 'upload-image', component: UploadimageComponent,canActivate: [AuthGuard]},
  { path: 'add-projects', component: AddprojectsComponent,canActivate: [AuthGuard]},
  { path: 'social-media', component: SocialmediaComponent,canActivate: [AuthGuard] },
  { path: 'social-media-form', component: SocialmediaformComponent,canActivate: [AuthGuard]},
  { path: 'facility', component: FacilityComponent,canActivate: [AuthGuard] },
  { path: '', component: SigninComponent },  // Wildcard route for a 404 page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
