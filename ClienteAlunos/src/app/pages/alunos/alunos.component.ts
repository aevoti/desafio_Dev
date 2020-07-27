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
  public exibirGerenciarAluno: boolean = this.listaAlunos.length > 0 ? false : true;

  constructor(private _alunoService: AlunoService, private _toastr: ToastrService) { }

  ngOnInit(): void {
    this.carregarAlunos();
    this._toastr.success('Hello world!', 'Toastr fun!');

  }

  public async carregarAlunos() {
    this.listaAlunosFiltrada = this.listaAlunos = await this._alunoService.obterAlunos();
  }

  public cliqueAdicionar() {
    this.alunoEditar = new Aluno();
    this.exibirGerenciarAluno = true;
  }

  public eventoEditarAluno(param: any) {
    this.exibirGerenciarAluno = true;
    this.alunoEditar.alunoId = param.alunoId;
    this.alunoEditar.nome = param.nome;
    this.alunoEditar.email = param.email;
  }

  public gerenciaBusca(param: any) {
    if (this.entradaBusca && this.entradaBusca.length == 0){
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
