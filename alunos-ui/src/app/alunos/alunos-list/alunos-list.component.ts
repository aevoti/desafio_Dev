import { Component, OnInit } from '@angular/core';

import { BehaviorSubject, combineLatest, Subject } from 'rxjs';
import { map, tap, startWith } from 'rxjs/operators';

import { Aluno } from '../aluno';
import { AlunosService } from '../alunos.service';
import { SortType } from 'src/app/shared/components/sort-btn/sort-btn.component';
import { AlertDialogService } from 'src/app/shared/components/alert-dialog/alert-dialog.service';
import { AlertDialogData, AlertType } from 'src/app/shared/components/alert-dialog/alert-dialog-data';


@Component({
  selector: 'aln-alunos-list',
  templateUrl: './alunos-list.component.html',
  styleUrls: ['./alunos-list.component.scss']
})
export class AlunosListComponent implements OnInit {

  paginatedAlunos$ = this.alunosService.getAll();

  currentFilter$ = new BehaviorSubject<string>('');
  nameSorting$ = new BehaviorSubject<SortType>(SortType.IDLE);
  idSorting$ = new BehaviorSubject<SortType>(SortType.ASC);
  page$ = new BehaviorSubject<number>(0);
  deleteEvent$ = new Subject<void>();

  readonly pageSize = 10;

  searchOpts$ = combineLatest(
    this.currentFilter$.asObservable(),
    this.nameSorting$.asObservable(),
    this.idSorting$.asObservable(),
    this.page$.asObservable(),
    this.deleteEvent$.asObservable().pipe(startWith(null))
  )

  constructor(private alunosService: AlunosService,
    private dialogService: AlertDialogService) { }

  ngOnInit(): void {
    this.searchOpts$
      .pipe(
        map(values => {
          const sortType = this.getSortStr(values[2], values[1]);
          const filter = values[0];
          const page = values[3];

          return { sortType, filter, page }
        }))
      .subscribe(searchOpts => {
        this.paginatedAlunos$ = this.alunosService
          .getAll(searchOpts.filter, searchOpts.sortType, searchOpts.page, this.pageSize);
      })
  }

  delete(aluno: Aluno) {
    this.alunosService
      .delete(aluno.alunoId)
      .subscribe(
        res => this.deleteEvent$.next(),
        err => { }
      )
  }

  openDeleteDialog(aluno: Aluno) {
    const dialogData: AlertDialogData = {
      title: 'Deseja prosseguir?',
      message: `Você realmente quer excluir o aluno ${aluno.nome}?`,
      showOKBtn: true,
      showCancelBtn: true,
      alertType: AlertType.WARNING
    };

    const dialogRef = this.dialogService.openDialog(
      dialogData, { disableClose: true });

    dialogRef.afterClosed().subscribe(ok => {
      if (ok) {
        this.delete(aluno);
      }
    });
  }

  onFilter(filterEvent: string) {
    this.currentFilter$.next(filterEvent);
    this.page$.next(0);
  }

  onNameSort(sortType: SortType) {
    this.nameSorting$.next(sortType);

    if (sortType == SortType.IDLE)
      this.idSorting$.next(SortType.ASC);
    else
      this.idSorting$.next(SortType.IDLE);

  }

  onIdSort(sortType: SortType) {
    this.idSorting$.next(sortType);
    this.nameSorting$.next(SortType.IDLE);
  }

  onPageChange(newPage: number) {
    this.page$.next(newPage);
  }

  private getSortStr(idSorting: SortType, nameSorting: SortType) {
    if (idSorting != SortType.IDLE) {
      switch (idSorting) {
        case SortType.ASC:
          return "ID_ASC";
        case SortType.DEC:
          return "ID_DEC";
      }
    }
    else {
      switch (nameSorting) {
        case SortType.ASC:
          return "NOME_ASC";
        case SortType.DEC:
          return "NOME_DEC";
      }
    }
  }
}
