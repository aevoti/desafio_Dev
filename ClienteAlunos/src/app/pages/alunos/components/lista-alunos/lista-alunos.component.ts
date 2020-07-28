import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Aluno } from 'src/app/models/alunoModel';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-lista-alunos',
  templateUrl: './lista-alunos.component.html',
  styleUrls: ['./lista-alunos.component.css']
})
export class ListaAlunosComponent implements OnInit {
  public p: number = 1;
  @Input() listaAlunos: Aluno[] = [];
  @Output() emitirEditarClique = new EventEmitter();
  @Output() emitirAtualizarListaParent = new EventEmitter();
  public idTipoOrdenacao: string = '0';
  public idAlunoExcluir: number = 0;

  constructor() { }

  ngOnInit(): void {
  }

  public reordenarLista(): void {
    switch (this.idTipoOrdenacao) {
      case '0': //ID CRESCENTE
        this.listaAlunos = this.listaAlunos.sort((a, b) => {
          if (a.alunoId > b.alunoId) {
            return 1;
          } else if (a.alunoId < b.alunoId) {
            return -1;
          } else {
            return 0;
          }
        });
        break;
      case '1': //ID DECRESCENTE
        this.listaAlunos = this.listaAlunos.sort((a, b) => {
          if (a.alunoId > b.alunoId) {
            return -1;
          } else if (a.alunoId < b.alunoId) {
            return 1;
          } else {
            return 0;
          }
        });
        break;
      case '2': //NOME CRESCENTE
        this.listaAlunos = this.listaAlunos.sort((a, b) => {
          if (a.nome > b.nome) {
            return 1;
          } else if (a.nome < b.nome) {
            return -1;
          } else {
            return 0;
          }
        });
        break;
      case '3': //NOME DECRESCENTE
        this.listaAlunos = this.listaAlunos.sort((a, b) => {
          if (a.nome > b.nome) {
            return -1;
          } else if (a.nome < b.nome) {
            return 1;
          } else {
            return 0;
          }
        });
        break;
      case '4': //EMAIL CRESCENTE
        this.listaAlunos = this.listaAlunos.sort((a, b) => {
          if (a.email > b.email) {
            return 1;
          } else if (a.email < b.email) {
            return -1;
          } else {
            return 0;
          }
        });
        break;
      case '5': //EMAIL DECRESCENTE
        this.listaAlunos = this.listaAlunos.sort((a, b) => {
          if (a.email > b.email) {
            return -1;
          } else if (a.email < b.email) {
            return 1;
          } else {
            return 0;
          }
        });
        break;
    }
  }

  public emitirEdicao(alunoId: number, nome: string, email: string): void {
    const _aluno: Aluno = new Aluno(alunoId, nome, email);
    this.emitirEditarClique.emit(_aluno);
  }

  public atualizaClienteExcluir(idAluno: number): void {
    this.idAlunoExcluir = idAluno;
  }

  public emitirAtualizarLista(): void{
    this.emitirAtualizarListaParent.emit(true);
  }

}
