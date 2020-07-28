import { Component, OnInit } from '@angular/core';

import { AlunosService } from '../alunos.service';

@Component({
  selector: 'aln-alunos-list',
  templateUrl: './alunos-list.component.html',
  styleUrls: ['./alunos-list.component.scss']
})
export class AlunosListComponent implements OnInit {

  alunos$ = this.alunosService.getAll();
  
  constructor(private alunosService: AlunosService) { }

  ngOnInit(): void {
  }


}
