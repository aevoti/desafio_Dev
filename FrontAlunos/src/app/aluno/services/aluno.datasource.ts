import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { INJECTOR, Inject } from '@angular/core';

import { Observable, BehaviorSubject, of } from 'rxjs';
import { catchError, finalize, map } from 'rxjs/operators';

import { Aluno } from '../../shared/models';
import { HttpService } from '../../shared/services';
import { HttpResponse } from '@angular/common/http';

export class AlunoDataSource implements DataSource<Aluno> {

  private alunosSubject = new BehaviorSubject<Aluno[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  public loading$ = this.loadingSubject.asObservable();

  constructor(
    private alunoService: HttpService<Aluno>
  ) {

  }

  connect(collectionViewer: CollectionViewer): Observable<Aluno[] | readonly Aluno[]> {
    return this.alunosSubject.asObservable();
  }
  disconnect(collectionViewer: CollectionViewer): void {
    this.alunosSubject.complete();
    this.loadingSubject.complete();
  }

  loadAlunos(nome = '', sortAttr = '', sortDirection = '', pageNumber = 0, pageSize = 10) {

    this.loadingSubject.next(true);

    this.alunoService.getAll([
      { key: 'nome', value: nome },
      { key: 'pageNumber', value: pageNumber.toString() },
      { key: 'pageSize', value: pageSize.toString() },
      { key: 'orderBy', value: sortAttr + ' ' + sortDirection}
    ])
      .pipe(
        catchError(() => of([])),
        finalize(() => this.loadingSubject.next(false)),
        map((alunos: HttpResponse<Aluno[]>) => alunos.body)
      )
      .subscribe(alunos => this.alunosSubject.next(alunos));

  }

}
