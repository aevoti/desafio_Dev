import { Component, OnInit } from '@angular/core';
import { Aluno } from 'src/app/models/alunoModel';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit {
  public idTipoOrdenacao: String = '0';
  public idAluno: number = 0;
  public nomeAluno: String = '';
  public emailAluno: String = '';

  public exibirAdicionarAluno: boolean = false;

  public listaAlunos: Aluno[] = [
    
  ];
  constructor() { }

  ngOnInit(): void {
    console.log(this.listaAlunos.length);
  }

  public btnEditarAluno(idAluno: number) {
    this.exibirAdicionarAluno = true;
    this.idAluno = idAluno;
    this.nomeAluno = 'Teste';
    this.emailAluno = 'Email';
  }

  public reordenarLista() {
    switch (this.idTipoOrdenacao) {
      case '0': //ID CRESCENTE
        this.listaAlunos = this.listaAlunos.sort((a, b) => {
          if (a.AlunoId > b.AlunoId) {
            return 1;
          } else if (a.AlunoId < b.AlunoId) {
            return -1;
          } else {
            return 0;
          }
        });
        break;
      case '1': //ID DECRESCENTE
        this.listaAlunos = this.listaAlunos.sort((a, b) => {
          if (a.AlunoId > b.AlunoId) {
            return -1;
          } else if (a.AlunoId < b.AlunoId) {
            return 1;
          } else {
            return 0;
          }
        });
        break;
      case '2': //NOME CRESCENTE
        this.listaAlunos = this.listaAlunos.sort((a, b) => {
          if (a.Nome > b.Nome) {
            return 1;
          } else if (a.Nome < b.Nome) {
            return -1;
          } else {
            return 0;
          }
        });
        break;
      case '3': //NOME DECRESCENTE
        this.listaAlunos = this.listaAlunos.sort((a, b) => {
          if (a.Nome > b.Nome) {
            return -1;
          } else if (a.Nome < b.Nome) {
            return 1;
          } else {
            return 0;
          }
        });
        break;
      case '4': //EMAIL CRESCENTE
        this.listaAlunos = this.listaAlunos.sort((a, b) => {
          if (a.Email > b.Email) {
            return 1;
          } else if (a.Email < b.Email) {
            return -1;
          } else {
            return 0;
          }
        });
        break;
      case '5': //EMAIL DECRESCENTE
        this.listaAlunos = this.listaAlunos.sort((a, b) => {
          if (a.Email > b.Email) {
            return -1;
          } else if (a.Email < b.Email) {
            return 1;
          } else {
            return 0;
          }
        });
        break;
    }
  }

}
