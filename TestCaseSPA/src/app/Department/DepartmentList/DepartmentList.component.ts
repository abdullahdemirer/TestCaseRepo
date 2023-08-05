import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../services/Department.service';
import { Department } from '../model/Department';
import { Router } from '@angular/router';

@Component({
  selector: 'app-DepartmentList',
  templateUrl: './DepartmentList.component.html',
  styleUrls: ['./DepartmentList.component.css']
})
export class DepartmentListComponent implements OnInit {

  constructor(
    private departmentService: DepartmentService,
    private router: Router
  ) { }

  showData = false;
  departmentList: Department[] = [];

  ngOnInit() {
    this.departmentService.getAllDepartment().subscribe({
      next: (data) => {
        this.departmentList = data;
        this.showData = true;
      },
        error: (e) => {
          console.log(e.message);
        },
      });
  }

  addNewDepartment(){
    this.router.navigateByUrl('/departments/0');
  }

  deleteDepartment(departmentId : number){
    console.log(departmentId);
    debugger;
    this.departmentService.deleteDepartment(departmentId).subscribe({
      next: (e) => {
        this.ngOnInit();
      },
        error: (e) => {
          console.log(e.message);
        },
      });
  }

  updateDepartment(departmentId : number){
    console.log(departmentId)
    this.router.navigateByUrl('/departments/'+departmentId);
  }
}
