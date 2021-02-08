import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Aluno } from '../models/aluno';

@Injectable({
  providedIn: 'root'
})
export class AlunosService {

  constructor(private http: HttpClient) { }

  // Request lista todos os alunos
  getAlunos(): Observable<Aluno[]> {
    let url = `${environment.urlApi}Alunos`;
    return this.http.get<Aluno[]>(url);
  }

  // Request cadastra um aluno
  cadastrarAluno(aluno: Aluno): Observable<Aluno> {
    let url = `${environment.urlApi}Alunos/`;
    return this.http.post<Aluno>(url, aluno);
  }

  // Request retorna aluno pelo id
  getAluno(alunoId: number): Observable<Aluno> {
    let url = `${environment.urlApi}Alunos/${alunoId}`;
    return this.http.get<Aluno>(url);
  }

  // Request realiza update em um aluno
  editarAluno(aluno: Aluno): Observable<Aluno> {
    console.log(aluno)
    let url = `${environment.urlApi}Alunos/${aluno.alunoId}`;
    return this.http.put<Aluno>(url, aluno);
  }

  // Request deleta aluno
  deleteAluno(alunoId: number): Observable<Aluno> {
    let url = `${environment.urlApi}Alunos/${alunoId}`;
    return this.http.delete<Aluno>(url);
  }

  // Request filtra alunos pelo nome
  filtrarAluno(nome: string): Observable<Aluno[]> {
    nome = encodeURI(nome);
    let url = `${environment.urlApi}Alunos/Filtro/${nome}`;
    return this.http.get<Aluno[]>(url);
  }
}
