import { Component, OnInit } from '@angular/core';
import { Personel } from '../model/Personel';
import { PersonelService } from '../services/Personel.service';
import { DepartmentService } from 'src/app/Department/services/Department.service';
import { Router } from '@angular/router';
import { PersonelDto } from '../model/PersonelDto';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-PersonelEdit',
  templateUrl: './PersonelEdit.component.html',
  styleUrls: ['./PersonelEdit.component.css']
})
export class PersonelEditComponent implements OnInit {

  constructor(
    private departmentService: DepartmentService,
    private personelService:PersonelService,
    private router: Router
  ) { }

  title = ""
  model: PersonelDto = new PersonelDto();
  departmentList = [];
  
  ngOnInit() {
    if(this.router.url.split('/')[2] == "0"){
      this.title = "Yeni Personel Ekle";
    }else{
      this.title = "Personeli Güncelle";
    }

    this.departmentService.getAllDepartment().subscribe({
      next: (data) => {
        this.departmentList = data;
      },
        error: (e) => {
          console.log(e.message);
        },
    });

    if(this.router.url.split('/')[2] != "0"){

      this.personelService.getPersonelById(parseInt(this.router.url.split('/')[2])).subscribe({
        next: (data) => {
          console.log(data)
          this.model = data;
          console.log(this.model)
        },
          error: (e) => {
            console.log(e.message);
          },
      });
    }
    
  }

  personEdit(form: NgForm){


  }

}
