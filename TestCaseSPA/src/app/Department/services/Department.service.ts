import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,  } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Department } from '../model/Department';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
 
  constructor(private http:HttpClient) { }
  path ="https://localhost:7235/api/Department"
  

  getAllDepartment():Observable<Department[]>{

    return this.http.get<Department[]>(this.path+"/GetAllDepartment")
  }

  addDepartment(department:Department){
  
    return this.http.post(this.path+"/AddDepartment",department)
  }

  updateDepartment(department:Department){
  
    return this.http.post(this.path+"/UpdateDepartment",department)
  }

  deleteDepartment(departmentId:number){
  
    const url = this.path + '/DeleteDepartment';
    return this.http.post(url, { departmentId });
  }

  getDepartmentById(deparmentId: number): Observable<Department>{
    var url = this.path+"/GetAllDepartment";
    let params = new HttpParams();
    params = params.append('departmentId', deparmentId);
    return this.http.get<Department>(url, { params });
  }
  
 
 
}
