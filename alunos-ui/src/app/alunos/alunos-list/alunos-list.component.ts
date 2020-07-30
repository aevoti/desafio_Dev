import { Component, OnInit } from '@angular/core';

import { BehaviorSubject, combineLatest, Subject } from 'rxjs';
import { map, tap, startWith } from 'rxjs/operators';

import { Aluno } from '../aluno';
import { AlunosService } from '../alunos.service';
import { SortType } from 'src/app/shared/components/sort-btn/sort-btn.component';

@Component({
  selector: 'aln-alunos-list',
  templateUrl: './alunos-list.component.html',
  styleUrls: ['./alunos-list.component.scss']
})
export class AlunosListComponent implements OnInit {

  alunos$ = this.alunosService.getAll();

  currentFilter$ = new BehaviorSubject<string>('');
  nameSorting$ = new BehaviorSubject<SortType>(SortType.IDLE);
  idSorting$ = new BehaviorSubject<SortType>(SortType.ASC);
  deleteEvent$ = new Subject<void>();

  searchOpts$ = combineLatest(this.currentFilter$.asObservable(),
    this.nameSorting$.asObservable(),
    this.idSorting$.asObservable(),
    this.deleteEvent$.asObservable().pipe(startWith(null))
  )

  constructor(private alunosService: AlunosService) { }

  ngOnInit(): void {
    this.searchOpts$
      .pipe(
        map(values => {
          const sortType = this.getSortStr(values[2], values[1]);
          const filter = values[0];

          return { sortType, filter }
        }))
      .subscribe(searchOpts => {
        this.alunos$ = this.alunosService.getAll(searchOpts.filter, searchOpts.sortType);
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

  onFilter(filterEvent: string) {
    this.currentFilter$.next(filterEvent);
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
