import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Aluno } from 'src/app/models/alunoModel';
import { AlunoService } from 'src/app/pages/alunos/services/aluno.service';

@Component({
  selector: 'app-modal-exclusao',
  templateUrl: './modal-exclusao.component.html',
  styleUrls: ['./modal-exclusao.component.css']
})
export class ModalExclusaoComponent implements OnInit {
  @Input() objetoExclusao: Aluno;
  @Output() emitirAtualizarLista = new EventEmitter();

  constructor(private _alunoService: AlunoService) { }

  ngOnInit(): void {
  }

  public async excluirAluno() {
    await this._alunoService.deletarAlunoPorId(this.objetoExclusao.alunoId).then();
    this.emitirAtualizarLista.emit(true);
    const botaoCancelar: HTMLElement = document.getElementById('btnCancelar') as HTMLElement;
    botaoCancelar.click();
  }
}
