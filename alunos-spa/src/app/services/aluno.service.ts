import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Aluno } from '../models/aluno.model';

@Injectable({
  providedIn: 'root'
})
export class AlunoService {
  private readonly API_URL = 'https://5000-da686bba-8ec4-47e7-8951-26d7a7e08908.ws-us02.gitpod.io/api/alunos/';

  constructor(private client: HttpClient) { }

  public get(): Observable<Aluno[]> {
    return this.client.get<Aluno[]>(this.API_URL);
  }

  public post(aluno: Aluno | any): Observable<Aluno> {
    return this.client.post<Aluno>(this.API_URL, aluno);
  }

  public put(aluno: Aluno): Observable<void> {
    return this.client.put<void>(this.API_URL + aluno.alunoId, aluno);
  }

  public delete(aluno: Aluno): Observable<Aluno> {
    return this.client.delete<Aluno>(this.API_URL + aluno.alunoId);
  }
}
