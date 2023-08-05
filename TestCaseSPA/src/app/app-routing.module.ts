import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonelListComponent } from './Personels/PersonelList/PersonelList.component';
import { DepartmentListComponent } from './Department/DepartmentList/DepartmentList.component';
import { PersonelEditComponent } from './Personels/PersonelEdit/PersonelEdit.component';
import { DepartmentEditComponent } from './Department/DepartmentEdit/DepartmentEdit.component';
import { NotFoundPageComponent } from './notFoundPage/notFoundPage.component';

const routes: Routes = [
  {path:'personels',component:PersonelListComponent},
  {path:'departments',component:DepartmentListComponent},
  {path:'',redirectTo:'personels',pathMatch:'full'},
  {path:'personels/:id',component:PersonelEditComponent},
  {path:'departments/:id',component:DepartmentEditComponent},
  {path:'**',component:NotFoundPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
