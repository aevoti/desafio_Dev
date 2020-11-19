import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Aluno } from '../models/aluno.model';
import { LoadingService } from '../services/loading.service';
import { AlunoService } from '../services/aluno.service';

@Component({
  selector: 'app-alunos-details',
  templateUrl: './alunos-details.component.html',
  styleUrls: ['./alunos-details.component.scss']
})
export class AlunosDetailsComponent implements OnInit {
  nome = new FormControl('', [Validators.required, Validators.minLength(3)]);
  email = new FormControl('', [Validators.required, Validators.email]);

  errors = {
    email: {
      required: 'Email é obrigatório',
      email: 'Email não é válido'
    },
    nome: {
      required: 'Nome é obrigatório',
      minlength: 'Nome de ter pelo menos 3 caracteres'
    }
  };

  constructor(private dialogRef: MatDialogRef<AlunosDetailsComponent>,
              @Inject(MAT_DIALOG_DATA) private data: Aluno,
              private loadingService: LoadingService,
              private alunoService: AlunoService) { }

  ngOnInit(): void {
    this.nome.setValue(this.data?.nome);
    this.email.setValue(this.data?.email);
  }

  getErrorMessage(formControl: FormControl, formControlName: string): string {
    return this.errors[formControlName][Object.keys(formControl.errors)[0]];
  }

  salvar(): void {
    if (this.email.invalid || this.nome.invalid) {
      this.email.markAsTouched();
      this.nome.markAsTouched();
      return;
    }
    this.loadingService.showLoading();

    const aluno: any = { email: this.email.value, nome: this.nome.value };
    if (!this.data) {
      // Quer dizer que tem que criar um aluno

      this.alunoService.post(aluno).subscribe({
        next: () => this.dialogRef.close(true),
      })
      .add(() => this.loadingService.hideLoading());
    } else {
      // Quer dizer que tem que atualizar um aluno

      aluno.alunoId = this.data.alunoId;
      this.alunoService.put(aluno).subscribe({
        next: () => this.dialogRef.close(true),
      })
      .add(() => this.loadingService.hideLoading());
    }
  }

  cancelar(): void {
    this.dialogRef.close(false);
  }

}
