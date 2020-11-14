import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ObterAlunosFilter } from '../filters/obter-alunos.filter';
import { AlunoViewModel } from '../models/aluno.view-model';
import { AlunoService } from '../services/aluno.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.scss'],
})
export class AlunoComponent implements OnInit {
  form: FormGroup;

  displayedColumns = ['id', 'nome', 'email', 'editar', 'remover'];
  alunos: AlunoViewModel[] = [];

  public loading = false;

  public alunoFilter: ObterAlunosFilter;

  constructor(private alunoService: AlunoService, fb: FormBuilder) {
    this.form = fb.group({
      id: [null, null],
      nome: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
    });

    this.alunoFilter = new ObterAlunosFilter();
  }

  ngOnInit(): void {
    this.carregarAlunos();
  }

  getNomeErrorMessage(): string {
    if (this.form.controls.nome.hasError('required')) {
      return 'Nome é obrigatório';
    }
    return '';
  }

  getEmailErrorMessage(): string {
    if (this.form.controls.email.hasError('required')) {
      return 'Email é obrigatório';
    }
    return this.form.controls.email.hasError('email') ? 'Email inválido.' : '';
  }

  carregarAlunos(): void {
    this.loading = true;
    this.alunoService.obterTodos(this.alunoFilter).subscribe(
      (retorno) => {
        this.alunos = retorno;
        this.loading = false;
      },
      (error) => {
        this.loading = false;
        Swal.fire({
          title: 'Erro!',
          text: 'Ocorreu um erro ao carregar os dados dos alunos. Por favor, tente novamente mais tarde.',
          icon: 'error',
        });
      },
      () => {
        this.loading = false;
      }
    );
  }

  submitForm($ev): void {
    $ev.preventDefault();
    for (const c in this.form.controls) {
      if (this.form.controls[c]) {
        this.form.controls[c].markAsTouched();
      }
    }
    if (this.form.valid) {
      const aluno = new AlunoViewModel(this.form.value);
      this.limparForm();
      this.loading = true;
      this.alunoService.inserirOuAtualizar(aluno.id, aluno).subscribe(
        (retorno) => {
          console.log(retorno);
          this.carregarAlunos();
        },
        (error) => {
          this.loading = false;
          Swal.fire(
            'Erro',
            'Ocorreu um erro ao inserir/alterar o aluno. Por favor, tente novamente mais tarde.',
            'error'
          );
        },
        () => {
          this.loading = false;
        }
      );
    }
  }

  removerAluno(aluno: AlunoViewModel): void {
    this.loading = true;
    this.alunoService.deletar(aluno?.id).subscribe((retorno) => {
      this.loading = false;
      console.log(retorno);
      this.carregarAlunos();
    });
  }

  editarAluno(aluno: AlunoViewModel): void {
    this.form.controls.id.setValue(aluno?.id);
    this.form.controls.nome.setValue(aluno?.nome);
    this.form.controls.email.setValue(aluno?.email);
  }

  limparForm(): void {
    this.form.markAsPristine();
    this.form.markAsUntouched();
    this.form.reset();
  }
}
