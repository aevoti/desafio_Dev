import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Aluno } from 'src/app/models/alunoModel';
import { AlunoService } from '../../services/aluno.service';
import { Observable } from 'rxjs';
AlunoService
@Component({
  selector: 'app-gerenciar-aluno',
  templateUrl: './gerenciar-aluno.component.html',
  styleUrls: ['./gerenciar-aluno.component.css']
})
export class GerenciarAlunoComponent implements OnInit {
  @Input() exibirGerenciarAluno: boolean;
  @Input() entidadeAluno: Aluno;
  @Output() emitirEsconderGerenciarAluno = new EventEmitter();

  constructor(private _alunoService: AlunoService) { }

  ngOnInit(): void {
  }

  public adicionarAluno() {
    if (this.entidadeAluno.alunoId == 0 || !this.entidadeAluno.alunoId) {
      this._alunoService.criarAluno(this.entidadeAluno);
    } else {
      this._alunoService.atualizarAluno(this.entidadeAluno);
    }
  }

}
