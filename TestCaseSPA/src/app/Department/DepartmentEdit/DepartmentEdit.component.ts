import { Component, OnInit } from '@angular/core';
import { Department } from '../model/Department';
import { DepartmentService } from '../services/Department.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-DepartmentEdit',
  templateUrl: './DepartmentEdit.component.html',
  styleUrls: ['./DepartmentEdit.component.css']
})
export class DepartmentEditComponent implements OnInit {

  constructor(
    private departmentService: DepartmentService,
    private router: Router
  ) { }

  title = ""
  model: Department = new Department();
  showUpdateButton = false;
  ngOnInit() {
    
    if(this.router.url.split('/')[2] == "0"){
      this.title = "Yeni Departman Ekle";
    }else{
      this.title = "Departman Güncelle";
    }

    if(this.router.url.split('/')[2] != "0"){

      this.departmentService.getDepartmentById(parseInt(this.router.url.split('/')[2])).subscribe({
        next: (data) => {
          this.model = data;
          this.showUpdateButton = true;
        },
          error: (e) => {
            console.log(e.message);
          },
      });
    }
  }

  deparmentEdit(form:NgForm){
    if(this.showUpdateButton){


    }else{
      this.departmentService.addDepartment(this.model).subscribe({
        next: (data) => {
          this.router.navigateByUrl('/departments');
        },
          error: (e) => {
            console.log(e.message);
          },
      })
    }
  }
}
