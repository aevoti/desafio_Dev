import { Injectable } from '@angular/core';
import { Aluno } from 'src/app/models/alunoModel';
import { Observable } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

var httpOptions = { headers: new HttpHeaders({ "Content-Type": "application/json" }) };

@Injectable({
  providedIn: 'root'
})

export class AlunoService {
  urlPathApi = environment.apiUrl;

  constructor(private http: HttpClient) { }

  obterAlunos(): Observable<Aluno[]> {
    return this.http.get<Aluno[]>(this.urlPathApi);
  }

  obterAlunoPorId(alunoid: number): Observable<Aluno> {
    const apiurl = `${this.urlPathApi}/${alunoid}`;
    return this.http.get<Aluno>(apiurl);
  }

  criarAluno(aluno: Aluno): Observable<Aluno> {
    return this.http.post<Aluno>(this.urlPathApi, aluno, httpOptions);
  }

  atualizarAluno(alunoid: string, aluno: Aluno): Observable<Aluno> {
    const apiurl = `${this.urlPathApi}/${alunoid}`;
    return this.http.put<Aluno>(apiurl, aluno, httpOptions);
  }

  deletarAlunoPorId(alunoid: string): Observable<number> {
    const apiurl = `${this.urlPathApi}/${alunoid}`;
    return this.http.delete<number>(apiurl, httpOptions);
  }
}
