import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.sass']
})
export class AlertComponent implements OnInit {

  @Input() class:string
  @Input() text:string

  constructor() { }

  ngOnInit(): void {
  }

}
