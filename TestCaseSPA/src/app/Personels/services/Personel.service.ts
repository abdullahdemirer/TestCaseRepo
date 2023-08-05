import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,  } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Personel } from '../model/Personel';
import { PersonelDto } from '../model/PersonelDto';


@Injectable({
  providedIn: 'root'
})
export class PersonelService {
  
  constructor(private http:HttpClient) { }
  path ="https://localhost:7235/api/Personel"
  

  getAllPersonel(departmentId?:number, startDate?:Date):Observable<PersonelDto[]>{
    var url = this.path+"/GetAllPersonel";

    let params = new HttpParams();
    if(departmentId!= null){
      params = params.append('departmentId', departmentId);
    }

    if(startDate != null){
      params = params.append('startDate', startDate.toISOString());
    }
    
    return this.http.get<PersonelDto[]>(url, { params });
  }

  addPersonel(personel:Personel){
  
    return this.http.post(this.path+"/AddPersonel",personel)
  }

  updatePersonel(personel:Personel){
  
    return this.http.post(this.path+"/UpdatePersonel",personel)
  }

  deletePersonel(personelId:number){
  
    return this.http.post(this.path+"/DeletePersonel",personelId)
  }

  getPersonelById(personelId: number): Observable<PersonelDto>{
    var url = this.path+"/GetAllPersonel";
    let params = new HttpParams();
    params = params.append('personelId', personelId);
    return this.http.get<PersonelDto>(url, { params });
  }
}
