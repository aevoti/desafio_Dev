import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Subscription, of } from 'rxjs';
import { switchMap, map, tap } from 'rxjs/operators';

import { AlunosService } from '../alunos.service';
import { Aluno } from '../aluno';
import { AlertType, AlertDialogData } from 'src/app/shared/components/alert-dialog/alert-dialog-data';
import { AlertDialogService } from 'src/app/shared/components/alert-dialog/alert-dialog.service';

@Component({
  selector: 'aln-alunos-form',
  templateUrl: './alunos-form.component.html',
  styleUrls: ['./alunos-form.component.scss']
})
export class AlunosFormComponent implements OnInit {

  pageTitle = "Novo Aluno"
  alunosForm: FormGroup;
  private currentAluno: Aluno;
  private editing: boolean = false;

  constructor(private formBuilder: FormBuilder,
    private alunosService: AlunosService,
    private route: ActivatedRoute,
    private dialogService: AlertDialogService,
    private router: Router) { }

  private routeSub: Subscription;
  ngOnInit(): void {
    this.routeSub = this.route.params
      .pipe(
        map(params => params['id']),
        tap(id => {
          if (!!id && id > 0) {
            this.pageTitle = "Editar Aluno"
            this.editing = true;
          }
        }),
        switchMap(id => {
          if (!!id && id > 0)
            return this.alunosService.getById(id);

          return of({ email: '', nome: '', id: 0 });
        }),
        tap((aluno: Aluno) => {
          this.currentAluno = aluno;
        })
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
    this.currentAluno = undefined;
    this.routeSub.unsubscribe();
  }

  onSubmit() {
    console.log(this.editing);
    if (this.editing) {
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
        res => this.openSuccessDialog("Usuário criado com sucesso"),
        err => { this.openFailureDialog("Não foi possível criar usuário") }
      );
  }

  updateAluno() {
    this.alunosService
      .update(this.currentAluno.alunoId, this.alunosForm.value)
      .subscribe(
        res => this.openSuccessDialog("Usuário editado com sucesso"),
        err => { this.openFailureDialog("Não foi possível editar usuário") }
      )
  }

  openSuccessDialog(successMsg: string) {
    const dialogData: AlertDialogData = {
      title: 'Sucesso!',
      message: successMsg,
      showOKBtn: true,
      showCancelBtn: false,
      alertType: AlertType.SUCCESS
    };

    const dialogRef = this.dialogService.openDialog(
      dialogData, { disableClose: false });

    dialogRef.afterClosed().subscribe(ok => {
      this.router.navigate(['alunos'])
    });
  }

  openFailureDialog(failureMsg: string) {
    const dialogData: AlertDialogData = {
      title: 'Erro!',
      message: failureMsg,
      showOKBtn: true,
      showCancelBtn: false,
      alertType: AlertType.DANGER
    };

    const dialogRef = this.dialogService.openDialog(
      dialogData, { disableClose: true });

    dialogRef.afterClosed().subscribe(ok => {
      this.alunosForm.reset();
    });
  }
}
