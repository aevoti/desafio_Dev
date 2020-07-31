
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Aluno } from 'src/app/models/alunoModel';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';

var httpOptions = { headers: new HttpHeaders({ "Content-Type": "application/json" }) };

@Injectable({
  providedIn: 'root'
})

export class AlunoService {
  urlPathApi = environment.apiUrl + 'alunos';

  constructor(private _http: HttpClient, private _toastr: ToastrService) { }

  async obterAlunos(): Promise<Aluno[]> {
    const retorno = await this._http.get<Aluno[]>(this.urlPathApi).toPromise().then();
    return retorno;
  }

  async obterAlunoPorId(alunoid: number): Promise<Aluno> {
    const apiurl = `${this.urlPathApi}/${alunoid}`;
    return await this._http.get<Aluno>(apiurl).toPromise().then();
  }

  async criarAluno(aluno: Aluno): Promise<void> {
    try {
      await this._http.post<Aluno>(this.urlPathApi, aluno, httpOptions).toPromise().then();
      this._toastr.success('Aluno cadastrado.', 'Sucesso!');
    } catch (error) {
      this._toastr.error('Houve um erro ao cadastrar.', 'Erro!');
    }
  }

  async atualizarAluno(aluno: Aluno): Promise<void> {
    try {
      const apiurl = `${this.urlPathApi}`;
      await this._http.put<Aluno>(apiurl, aluno, httpOptions).toPromise().then();
      this._toastr.success('Aluno atualizado.', 'Sucesso!');
    } catch (error) {
      this._toastr.error('Houve um erro ao atualizar.', 'Erro!');
    }
  }

  async deletarAlunoPorId(alunoid: number): Promise<void> {
    try {
      const apiurl = `${this.urlPathApi}/${alunoid}`;
      await this._http.delete<number>(apiurl, httpOptions).toPromise().then();
      this._toastr.success('Aluno excluído.', 'Sucesso!');
    } catch (error) {
      this._toastr.error('Houve um erro ao excluir.', 'Erro!');
    }
  }
}
