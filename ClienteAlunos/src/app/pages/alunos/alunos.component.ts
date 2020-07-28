import { Component, OnInit } from '@angular/core';
import { Aluno } from 'src/app/models/alunoModel';
import { AlunoService } from './services/aluno.service';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit {
  public entradaBusca: string;
  public alunoEditar: Aluno = new Aluno();
  public listaAlunos: Aluno[] = [];
  public listaAlunosFiltrada: Aluno[] = [];
  public exibirGerenciarAluno: boolean = false;

  constructor(private _alunoService: AlunoService, private _toastr: ToastrService) { }

  ngOnInit(): void {
    this.carregarAlunos();
  }

  public async carregarAlunos() {
    this.listaAlunosFiltrada = this.listaAlunos = await this._alunoService.obterAlunos();
    this.exibirGerenciarAluno = this.listaAlunos.length > 0 ? false : true;
  }

  public cliqueAdicionar() {
    this.exibirGerenciarAluno = false;
    this.alunoEditar = new Aluno();
    this.exibirGerenciarAluno = true;
  }

  public eventoEditarAluno(param: any) {
    console.log('editar aluno');
    this.exibirGerenciarAluno = false;
    this.alunoEditar.alunoId = param.alunoId;
    this.alunoEditar.nome = param.nome;
    this.alunoEditar.email = param.email;
    this.exibirGerenciarAluno = true;
  }

  public gerenciaBusca(param: any) {
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
