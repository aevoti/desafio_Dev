import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Aluno } from 'src/app/models/alunoModel';
import { AlunoService } from 'src/app/pages/alunos/services/aluno.service';

@Component({
  selector: 'app-modal-exclusao',
  templateUrl: './modal-exclusao.component.html',
  styleUrls: ['./modal-exclusao.component.css']
})
export class ModalExclusaoComponent implements OnInit {
  @Input() idAlunoExclusao: number;
  @Output() emitirAtualizarLista = new EventEmitter();
  public alunoExcluir: Aluno = new Aluno();

  constructor(private _alunoService: AlunoService) { }

  ngOnInit(): void {
  }

  ngOnChanges(): void {
    this._buscarAluno();
  }

  private async _buscarAluno(): Promise<void> {
    this.alunoExcluir = await this._alunoService.obterAlunoPorId(this.idAlunoExclusao);
  }

  public async excluirAluno(): Promise<void> {
    await this._alunoService.deletarAlunoPorId(this.idAlunoExclusao).then();
    this.emitirAtualizarLista.emit(true);
    //Fechando Modal
    const botaoCancelar: HTMLElement = document.getElementById('btnCancelar') as HTMLElement;
    botaoCancelar.click();
  }
}
