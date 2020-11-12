import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { AlunoService } from '../services/aluno.service';
import { Aluno } from '../models/aluno';
import {Sort} from '@angular/material/sort';


@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.css']
})
export class AlunoComponent implements OnInit {

  dataSaved = false;
  alunoNaoEncontrado = false;
  alunoForm: any;
  allAlunos: Observable<Aluno[]>;
  alunoIdUpdate = null;
  message = null;
  opcaoPesquisa: string;
  @ViewChild("campoBusca") campoBuscaElement: ElementRef;
  key: string;
  reverse = false;

  constructor(private formbulider: FormBuilder, private alunoService: AlunoService, private element: ElementRef) { }

  ngOnInit(): void {
    this.alunoForm = this.formbulider.group({
      Nome: ['', [Validators.required]],
      Email: ['', [Validators.required, Validators.email]],
    });
    this.loadAllAlunos();
    this.opcaoPesquisa = '1';
  }

  sortAlunos(key): void {
    this.key = key;
    this.reverse = !this.reverse;
  }

  loadAllAlunos(): void {
    this.allAlunos = this.alunoService.getAllAlunos();
  }

  onFormSubmit(): void {
    this.dataSaved = false;
    this.alunoNaoEncontrado = false;
    const aluno = this.alunoForm.value;
    this.CreateAluno(aluno);
    this.alunoForm.reset();
  }

  CreateAluno(aluno: Aluno): void{
    if (this.alunoIdUpdate == null){
      this.alunoService.createAluno(aluno).subscribe(
        () => {
          this.dataSaved = true;
          this.alunoNaoEncontrado = false;
          this.message = 'Cadastro do aluno realizado com sucesso';
          this.loadAllAlunos();
          this.alunoIdUpdate = null;
          this.alunoForm.reset();
          this.campoBuscaElement.nativeElement.value = null;
        }
      );
    }else {
      aluno.alunoId = this.alunoIdUpdate;
      this.alunoService.updateAluno(this.alunoIdUpdate, aluno).subscribe(
        () => {
          this.dataSaved = true;
          this.alunoNaoEncontrado = false;
          this.message = 'Cadastro do aluno atualizado com sucesso';
          this.loadAllAlunos();
          this.alunoIdUpdate = null;
          this.alunoForm.reset();
          this.campoBuscaElement.nativeElement.value = null;
        }
      );
    }
  }

  loadAlunoToEdit(alunoid: string): void{
    this.alunoService.getAlunoById(alunoid).subscribe(
      aluno => {
        this.message = null;
        this.dataSaved = false;
        this.alunoIdUpdate = aluno.alunoId;
        this.alunoForm.controls.Nome.setValue(aluno.nome);
        this.alunoForm.controls.Email.setValue(aluno.email);
      }
    );
  }

  pesquisarAluno(campoBusca: string): void{
    if (this.opcaoPesquisa == '1'){
      this.alunoService.getAlunoByName(campoBusca).subscribe(
        aluno => {
            this.message = null;
            this.dataSaved = false;
            this.alunoIdUpdate = aluno.alunoId;
            this.alunoForm.controls.Nome.setValue(aluno.nome);
            this.alunoForm.controls.Email.setValue(aluno.email);
        },
        (err) => {
          this.message = 'Aluno não encontrado';
          this.alunoNaoEncontrado = true;
        }
      );
    }else{
      this.alunoService.getAlunoById(campoBusca).subscribe(
        aluno => {
          this.message = null;
          this.dataSaved = false;
          this.alunoIdUpdate = aluno.alunoId;
          this.alunoForm.controls.Nome.setValue(aluno.nome);
          this.alunoForm.controls.Email.setValue(aluno.email);
        },
        (err) => {
          this.message = 'Aluno não encontrado';
          this.alunoNaoEncontrado = true;
        }
      );
    }
  }

  deleteAluno(alunoid: string): void{
    if (confirm('Deseja realmente excluir o cadastro desse aluno ?')){
      this.alunoService.deleteAlunoById(alunoid).subscribe(
        () => {
            this.dataSaved = true;
            this.message = 'Cadastro do anulo foi excluído com sucesso';
            this.loadAllAlunos();
            this.alunoIdUpdate = null;
            this.alunoForm.reset();
          }
        );
    }
  }

  resetForm(): void{
    this.alunoForm.reset();
    this.message = null;
    this.dataSaved = true;
    this.alunoNaoEncontrado = false;
  }

}

function compare(a: number | string, b: number | string, isAsc: boolean) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
