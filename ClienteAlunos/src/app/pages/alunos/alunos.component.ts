import { Component, OnInit } from '@angular/core';
import { Aluno } from 'src/app/models/alunoModel';
import { AlunoService } from './services/aluno.service';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit {
  public entradaBusca: string;
  public entidadeAluno: Aluno = new Aluno();
  public listaAlunos: Aluno[] = [];
  public listaAlunosFiltrada: Aluno[] = [];
  public exibirGerenciarAluno: boolean = false;
  alunoForm: any;

  constructor(private _alunoService: AlunoService, private _toastr: ToastrService, private _formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.preencherForm();
    this.carregarAlunos();
  }

  public preencherForm(): void {
    this.alunoForm = this._formBuilder.group({
      alunoId: [this.entidadeAluno.alunoId || 0],
      nome: [this.entidadeAluno.nome, [Validators.required]],
      email: [this.entidadeAluno.email, [Validators.required, Validators.email]],
    });
    this.exibirGerenciarAluno = true;
  }

  public async carregarAlunos(): Promise<void> {
    this.listaAlunosFiltrada = this.listaAlunos = await this._alunoService.obterAlunos();
    this.exibirGerenciarAluno = this.listaAlunos.length > 0 ? false : true;
  }

  public cliqueAdicionar(): void {
    this.entidadeAluno = new Aluno();
    this.preencherForm();
  }

  public eventoEditarAluno(param: any): void {
    this.entidadeAluno.alunoId = param.alunoId;
    this.entidadeAluno.nome = param.nome;
    this.entidadeAluno.email = param.email;
    this.preencherForm();
  }

  public async submitFormulario(aluno: Aluno): Promise<void> {
    debugger;
    if (!this.entidadeAluno.alunoId || this.entidadeAluno.alunoId == 0) {
      await this._alunoService.criarAluno(aluno);
    } else {
      await this._alunoService.atualizarAluno(aluno);
    }
    this.alunoForm.reset();
    this.exibirGerenciarAluno = false;
    this.carregarAlunos();
  }

  public gerenciaBusca(param: any): void {
    if (this.entradaBusca.length == 0) {
      this.listaAlunosFiltrada = this.listaAlunos;
      return;
    }

    if (isNaN(Number(this.entradaBusca))) { //BuscaNome
      this.listaAlunosFiltrada = this.listaAlunos.filter(x => x.nome.toUpperCase().match(this.entradaBusca.toUpperCase()));
    } else { //BuscaId
      this.listaAlunosFiltrada = this.listaAlunos.filter(x => x.alunoId == Number(this.entradaBusca));
    }
  }

}
