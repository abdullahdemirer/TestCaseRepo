import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  constructor() { }

  title = 'Kategori Listesi';
  
  ngOnInit() {
  }
  
  removeActiveClass() {
    var allButtons = document.querySelectorAll('.list-group-item');
    allButtons.forEach(x=> x.classList.remove('active'));
  }

  changeButtonCss(e:any){
    this.removeActiveClass();
    var button = document.getElementById(e.srcElement.id);
    button?.classList.add('active');
   
  }

}
