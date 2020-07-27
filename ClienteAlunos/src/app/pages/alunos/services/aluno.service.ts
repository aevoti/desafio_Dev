
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Aluno } from 'src/app/models/alunoModel';
import { environment } from 'src/environments/environment';

var httpOptions = { headers: new HttpHeaders({ "Content-Type": "application/json" }) };

@Injectable({
  providedIn: 'root'
})

export class AlunoService {
  urlPathApi = environment.apiUrl + 'alunos/';

  constructor(private http: HttpClient) { }

  async obterAlunos(): Promise<Aluno[]> {
    const retorno = await this.http.get<Aluno[]>(this.urlPathApi).toPromise().then();
    return retorno;
  }

  async obterAlunoPorId(alunoid: number): Promise<Aluno[]> {
    const apiurl = `${this.urlPathApi}/${alunoid}`;
    return await this.http.get<Aluno>(apiurl).toPromise().then();
  }

  async criarAluno(aluno: Aluno): Promise<Boolean> {
    try {
      await this.http.post<Aluno>(this.urlPathApi, aluno, httpOptions).toPromise().then();
      return true;
    } catch (error) {
      console.log(error);
    }
  }

  async atualizarAluno(aluno: Aluno): Promise<Boolean> {
    try {
      const apiurl = `${this.urlPathApi}/${aluno.alunoId}`;
      await this.http.put<Aluno>(apiurl, aluno, httpOptions).toPromise().then();
      return true;
    } catch (error) {
      console.log(error);
    }
  }

  async deletarAlunoPorId(alunoid: number): Promise<Boolean> {
    try {
      const apiurl = `${this.urlPathApi}${alunoid}`;
      await this.http.delete<number>(apiurl, httpOptions).toPromise().then();
      return true;
    } catch (error) {
      console.log(error);
    }
  }
}
