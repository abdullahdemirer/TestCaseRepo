import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
// import {ToastrModule} from 'ngx-toastr';
// import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NotFoundPageComponent } from './notFoundPage/notFoundPage.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CategoryComponent } from './Category/category.component';
import { PersonelListComponent } from './Personels/PersonelList/PersonelList.component';
import { PersonelEditComponent } from './Personels/PersonelEdit/PersonelEdit.component';
import { DepartmentEditComponent } from './Department/DepartmentEdit/DepartmentEdit.component';
import { DepartmentListComponent } from './Department/DepartmentList/DepartmentList.component';

@NgModule({
  declarations: [				
    AppComponent,
      NotFoundPageComponent,
      NavbarComponent,
      CategoryComponent,
      PersonelListComponent,
      PersonelEditComponent,
      DepartmentEditComponent,
      DepartmentListComponent,
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    // BrowserAnimationsModule,
    FormsModule,
    // ToastrModule.forRoot({
    //   timeOut:1000,
    //   progressBar:true,
    //   progressAnimation:'increasing',

    // })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
