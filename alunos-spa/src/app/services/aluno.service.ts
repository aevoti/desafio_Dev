import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Aluno } from '../models/aluno.model';
import { AppComponent } from '../app.component';

@Injectable({
  providedIn: 'root'
})
export class AlunoService {
  private readonly API_ROUTE = AppComponent.API_URL + '/api/alunos/';

  constructor(private client: HttpClient) { }

  public get(): Observable<Aluno[]> {
    return this.client.get<Aluno[]>(this.API_ROUTE);
  }

  public post(aluno: Aluno | any): Observable<Aluno> {
    return this.client.post<Aluno>(this.API_ROUTE, aluno);
  }

  public put(aluno: Aluno): Observable<void> {
    return this.client.put<void>(this.API_ROUTE + aluno.alunoId, aluno);
  }

  public delete(aluno: Aluno): Observable<Aluno> {
    return this.client.delete<Aluno>(this.API_ROUTE + aluno.alunoId);
  }
}
