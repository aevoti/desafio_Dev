import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-subtitle',
  templateUrl: './subtitle.component.html',
  styleUrls: ['./subtitle.component.sass']
})
export class SubtitleComponent implements OnInit {

  @Input() subtitle:string = 'subtítulo'

  constructor() { }

  ngOnInit() {
  }

}
