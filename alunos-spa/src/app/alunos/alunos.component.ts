import { Component, OnInit } from '@angular/core';
import { Aluno } from '../models/aluno.model';
import { AlunoService } from '../services/aluno.service';
import { LoadingService } from '../services/loading.service';
import { MatDialog } from '@angular/material/dialog';
import { AlunosDetailsComponent } from '../alunos-details/alunos-details.component';
import { ConfirmarDialogComponent } from '../confirmar-dialog/confirmar-dialog.component';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.scss']
})
export class AlunosComponent implements OnInit {

  dataSource: Aluno[];
  displayedColumns = ['nome', 'email', 'acoes'];

  constructor(private alunoService: AlunoService, private loadingService: LoadingService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.dataSource = [];
    this.loadingService.showLoading();

    this.alunoService.get().subscribe({
      next: (data) => this.dataSource = data,
    })
    .add(() => this.loadingService.hideLoading());
  }

  addOrUpdate(aluno: Aluno = null): void {
    const dialogRef = this.dialog.open(AlunosDetailsComponent, {
      width: '30%',
      minWidth: '400px',
      data: aluno
    });

    dialogRef.afterClosed().subscribe(result => { if (result) { this.load(); } });
  }

  del(aluno: Aluno): void {
    const dialogRef = this.dialog.open(ConfirmarDialogComponent, {
      width: '30%',
      minWidth: '400px',
      data: {
        message: 'Deseja mesmo excluir este aluno?',
        header: 'Confirmar remoção',
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadingService.showLoading();

        this.alunoService.delete(aluno).subscribe({
          next: () => this.load(),
        })
        .add(() => this.loadingService.hideLoading());
      }
    });
  }

}
