import { Component, OnInit } from '@angular/core';

import { AlunosService } from '../alunos.service';
import { Aluno } from '../aluno';

@Component({
  selector: 'aln-alunos-list',
  templateUrl: './alunos-list.component.html',
  styleUrls: ['./alunos-list.component.scss']
})
export class AlunosListComponent implements OnInit {

  alunos$ = this.alunosService.getAll();
  currentFilter = '';
  
  constructor(private alunosService: AlunosService) { }

  ngOnInit(): void {
  }

  delete(aluno: Aluno){
    this.alunosService
      .delete(aluno.alunoId)
      .subscribe(
        res => this.alunos$ = this.alunosService.getAll(),
        err => {}
      )
  }

  onFilter(filterEvent: string) {
    this.currentFilter = filterEvent
    this.alunos$ = this.alunosService.getAll(filterEvent)
  }
}
