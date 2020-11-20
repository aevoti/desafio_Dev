import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { Aluno } from '../models/aluno.model';
import { AlunoService } from '../services/aluno.service';
import { LoadingService } from '../services/loading.service';
import { MatDialog } from '@angular/material/dialog';
import { AlunosDetailsComponent } from '../alunos-details/alunos-details.component';
import { ConfirmarDialogComponent } from '../confirmar-dialog/confirmar-dialog.component';
import { ToastService } from '../services/toast.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.scss']
})
export class AlunosComponent implements AfterViewInit {

  dataSource = new MatTableDataSource<Aluno>();
  displayedColumns = ['nome', 'email', 'acoes'];

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private alunoService: AlunoService,
    private loadingService: LoadingService,
    private dialog: MatDialog,
    private toastService: ToastService
    ) { }


  ngAfterViewInit(): void {
    this.dataSource.filterPredicate = (data: Aluno, filter: string) => data.nome.indexOf(filter) != -1;
    this.dataSource.paginator = this.paginator;

    this.load();
  }

  ngOnInit(): void {
  }

  load(): void {
    this.dataSource.data = [];
    this.loadingService.showLoading();

    this.alunoService.get().subscribe({
      next: (data) => this.dataSource.data = data,
      error: () => this.toastService.showErrorToast()
    })
    .add(() => this.loadingService.hideLoading());
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
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
          next: () => {
            this.toastService.showSuccessToast('Aluno removido com sucesso!');
            this.load();
          },
          error: () => this.toastService.showErrorToast()
        })
        .add(() => this.loadingService.hideLoading());
      }
    });
  }

}
