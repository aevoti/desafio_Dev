import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Aluno } from '../models/aluno';
import { AlunosService } from '../services/alunos.service';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.scss']
})

export class AlunosComponent implements OnInit {

  listaAlunos: Aluno[] = [];
  aluno: Aluno;
  modoSalvar: string;
  bodyDeletarAluno: string;
  inputBuscarAluno: string;

  modalRef: BsModalRef;
  registerForm: FormGroup;

  constructor(
    private alunosService: AlunosService,
    private modalService: BsModalService,
    private toastr: ToastrService
    ) { }

  ngOnInit(): void {
    this.getAlunos();
    this.validacao();
  }

  // Método abrir modal
  abrirModal(template: TemplateRef<any>) {
    this.registerForm.reset();
    this.modalRef = this.modalService.show(template); 
  }

  // Método que valida os campos do formulário
  validacao() {
    this.registerForm = new FormGroup({
      nome: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email])
    });
  }

  // Método que preenche a lista de alunos
  getAlunos() {
    this.alunosService.getAlunos().subscribe(
      data => {
        this.listaAlunos = data;
      },
      error => {
        console.log(error);
      }
    );
  }

  // Método abre modal para cadastro de novo aluno
  novoAluno(template: TemplateRef<any>) {
    this.modoSalvar = 'post';
    this.abrirModal(template);
  }

  // Método abre modal para edição de aluno
  editarAluno(aluno: Aluno, template: TemplateRef<any>) {
    this.modoSalvar = 'put';
    this.abrirModal(template);
    this.aluno = aluno;
    this.registerForm.patchValue(aluno);
  }

  // Método abre modal para confirmação da exclusão
  excluirAluno(aluno: Aluno, template: TemplateRef<any>) {
    this.abrirModal(template);
    this.aluno = aluno;
    this.bodyDeletarAluno = `Tem certeza que deseja excluir o aluno ${aluno.nome}?`;
  }

  // Método do botão salvar em editar/cadastrar
  // Se modoSalvar == 'post' é cadastro novo
  // Senão é edição
  salvarAluno() {
    if(this.registerForm.valid) {
      if(this.modoSalvar === 'post') {
        this.aluno = Object.assign({}, this.registerForm.value);
        this.alunosService.cadastrarAluno(this.aluno).subscribe(
        () => {
          this.modalRef.hide();
          this.getAlunos();
          this.toastr.success('Aluno inserido com sucesso!')
        },
        error => {
          this.toastr.error('Não foi possível inserir o aluno. Tente novamente mais tarde.')
        });
      } else {
        this.aluno = Object.assign({alunoId: this.aluno.alunoId}, this.registerForm.value);
        this.alunosService.editarAluno(this.aluno).subscribe(
        () => {
          this.modalRef.hide();
          this.getAlunos();
          this.toastr.success('Aluno atualizado com sucesso!')
        },
        error => {
          this.toastr.error('Não foi possível atualizar o aluno. Tente novamente mais tarde.')
        });
      }
    }
  }

  // Método que realiza a exclusão
  confirmarExclusao(template: any) {
    this.alunosService.deleteAluno(this.aluno.alunoId).subscribe(
      () => {
        this.modalRef.hide();
        this.getAlunos();
        this.toastr.success('Aluno excluído com sucesso!')
      }, 
      error => {
        this.toastr.error('Não foi possível excluir o aluno. Tente novamente mais tarde.')
      }
    );
  }

  // Método preenche lista de alunos filtrados pelo input nome
  // Se campo estiver vazio, retorna todos os alunos cadastrados
  buscarAluno() {
    if(this.inputBuscarAluno) {
      this.alunosService.filtrarAluno(this.inputBuscarAluno).subscribe(
        data => {
          this.listaAlunos = data;
        },
        error => {
          this.toastr.error('Não foi possível carregar os aluno. Tente novamente mais tarde.')
        }
      )
    } else {
      this.getAlunos();
    }
  }
}
