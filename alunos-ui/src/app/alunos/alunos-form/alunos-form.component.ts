import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Subscription, of } from 'rxjs';
import { switchMap, map, tap } from 'rxjs/operators';

import { AlunosService } from '../alunos.service';
import { Aluno } from '../aluno';

@Component({
  selector: 'aln-alunos-form',
  templateUrl: './alunos-form.component.html',
  styleUrls: ['./alunos-form.component.scss']
})
export class AlunosFormComponent implements OnInit {

  pageTitle = "Novo Aluno"
  alunosForm: FormGroup;
  private currentAluno: Aluno;

  constructor(private formBuilder: FormBuilder,
    private alunosService: AlunosService,
    private route: ActivatedRoute) { }

  private routeSub: Subscription;
  ngOnInit(): void {
    this.routeSub = this.route.params
      .pipe(
        map(params => params['id']),
        tap(id => {
          if (id)
            this.pageTitle = "Editar Aluno"
        }),
        switchMap(id => {
          if (id)
            return this.alunosService.getById(id);

          return of({ email: '', nome: '', id: 0 });
        }),
        tap((aluno: Aluno) => this.currentAluno = aluno)
      )
      .subscribe(a => {
        this.buildForm(a.email, a.nome);
      });
  }

  buildForm(email: string, nome: string) {
    this.alunosForm = this.formBuilder.group({
      nome: [
        nome,
        [Validators.required, Validators.minLength(3), Validators.maxLength(100)]
      ],
      email: [
        email,
        [Validators.required, Validators.email]
      ],
    });
  }

  ngOnDestroy(): void {
    this.routeSub.unsubscribe();
  }

  onSubmit() {
    if (this.currentAluno) {
      this.updateAluno();
    }
    else {
      this.registerAluno();
    }
  }

  registerAluno() {
    this.alunosService
      .register(this.alunosForm.value)
      .subscribe(
        res => {
          console.log('REGISTERED');
        },
        err => { this.alunosForm.reset() }
      );
  }

  updateAluno() {
    this.alunosService
      .update(this.currentAluno.alunoId, this.alunosForm.value)
      .subscribe(
        res => console.log("UPDATED"),
        err => {console.log(err); this.alunosForm.reset()}
      )
  }
}
