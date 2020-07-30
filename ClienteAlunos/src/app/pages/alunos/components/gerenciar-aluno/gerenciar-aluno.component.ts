import { Component, OnInit, Input, Output, EventEmitter, destroyPlatform } from '@angular/core';
import { Aluno } from 'src/app/models/alunoModel';
import { AlunoService } from '../../services/aluno.service';
import { Observable } from 'rxjs';
import { FormBuilder, Validators } from '@angular/forms';

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
  @Output() emitirAtualizarListaParent = new EventEmitter();
  alunoForm: any;

  constructor(private _formBuilder: FormBuilder, private _alunoService: AlunoService) { }

  ngOnInit(): void {
    this.alunoForm = this._formBuilder.group({
      alunoId: [this.entidadeAluno.alunoId],
      nome: [this.entidadeAluno.nome, [Validators.required]],
      email: [this.entidadeAluno.nome, [Validators.required]],
    });
  }

  ngOnChanges(): void {
    console.log(this.entidadeAluno);
    this.alunoForm.controls['alunoId'].setValue(this.entidadeAluno.alunoId);
    this.alunoForm.controls['nome'].setValue(this.entidadeAluno.nome);
    this.alunoForm.controls['email'].setValue(this.entidadeAluno.email);
  }

  public async submitFormulario(aluno: Aluno): Promise<void> {
    if (!this.entidadeAluno.alunoId || this.entidadeAluno.alunoId == 0) {
      await this._alunoService.criarAluno(aluno);
    } else {
      await this._alunoService.atualizarAluno(aluno);
    }
    this.alunoForm.reset();
    this.emitirEsconderGerenciarAluno.emit(true);
    this.emitirAtualizarListaParent.emit(true);
  }
}
