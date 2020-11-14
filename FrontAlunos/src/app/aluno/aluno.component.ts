import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ObterAlunosFilter } from '../filters/obter-alunos.filter';
import { AlunoViewModel } from '../models/aluno.view-model';
import { AlunoService } from '../services/aluno.service';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.scss']
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
      email: [null, [Validators.required, Validators.email]]
    });

    this.alunoFilter = new ObterAlunosFilter();
   }

  ngOnInit(): void {
    this.carregarAlunos();
  }


  getNomeErrorMessage() {
    if (this.form.controls['nome'].hasError('required')) {
      return 'Nome é obrigatório';
    }
    return '';
  }

  getEmailErrorMessage() {
    if (this.form.controls['email'].hasError('required')) {
      return 'Email é obrigatório';
    }
    return this.form.controls['email'].hasError('email') ? 'Email inválido.' : '';
  }

  carregarAlunos() {
    this.loading = true;
    this.alunoService.obterTodos(this.alunoFilter).subscribe((retorno) => {
      this.alunos = retorno;
      this.loading = false;
    })
  }

  submitForm($ev) {
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
          this.loading = false;
          console.log(retorno);
          this.carregarAlunos();
        },
        (err) => {
          console.log(err);
        }
      );
    }
  }

  removerAluno(aluno: AlunoViewModel) {
    this.loading = true;
    this.alunoService.deletar(aluno?.id).subscribe((retorno) => {
      this.loading = false;
      console.log(retorno);
      this.carregarAlunos();
    })
  }

  editarAluno(aluno: AlunoViewModel) {
    this.form.controls['id'].setValue(aluno?.id);
    this.form.controls['nome'].setValue(aluno?.nome);
    this.form.controls['email'].setValue(aluno?.email);
  }


  limparForm(){
    this.form.markAsPristine();
    this.form.markAsUntouched();
    this.form.reset();
  }
}
