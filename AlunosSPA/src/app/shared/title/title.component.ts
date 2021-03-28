import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.sass']
})
export class TitleComponent implements OnInit {

  @Input() title:string = 'título'

  constructor() { }

  ngOnInit() {
  }

}
