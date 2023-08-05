import { Component, OnInit } from '@angular/core';
import { PersonelService } from '../services/Personel.service';
import { PersonelDto } from '../model/PersonelDto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-PersonelList',
  templateUrl: './PersonelList.component.html',
  styleUrls: ['./PersonelList.component.css']
})
export class PersonelListComponent implements OnInit {

  constructor(
    private personelService: PersonelService,
    private router: Router
  ) { }

  showData = false;
  personelList: PersonelDto[] = [];

  filterDepartmentId =null;
  filterStartDate =null;

  ngOnInit() {

    this.personelService.getAllPersonel(this.filterDepartmentId,this.filterStartDate).subscribe({
      next: (data) => {
        this.personelList = data;
        this.showData = true;
      },
        error: (e) => {
          console.log(e.message);
          // this.alert.error("Hata meydana geldi.")
        },
      });
  }

  addNewPersonel(){
    this.router.navigateByUrl('/personels/0');
  }

  updatePersonel(pesronelId : number){
    this.router.navigateByUrl('/personels/'+pesronelId);
  }

  deletePersonel(pesronelId : number){

  }

}
