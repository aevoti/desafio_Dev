import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { AlunoViewModel } from '../models/aluno.view-model';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { ObterAlunosFilter } from '../filters/obter-alunos.filter';


@Injectable({
  providedIn: 'root',
})
export class AlunoService {
  protected nomeController: string;

  protected caminhoApi: string;

  constructor(private http: HttpClient) {
    this.nomeController = 'Alunos';
    this.caminhoApi = `${this.removeTrailingSlashes(environment?.apiUrl)}/${this.nomeController}`;

  }

  obterPorId(id: number) : Observable<AlunoViewModel> {
    return this.http
      .get<AlunoViewModel>(`${this.caminhoApi}/${id}`)
      .pipe(catchError(this.handleError));
  }

  obterTodos(filtro: ObterAlunosFilter) : Observable<AlunoViewModel[]> {
    let params = new HttpParams();
    if (filtro?.nome) {
      params = params
      .set('nome', `${filtro?.nome}`);
    }

    return this.http
      .get<AlunoViewModel[]>(`${this.caminhoApi}`, { params })
      .pipe(catchError(this.handleError));
  }

  deletar(id: number) : Observable<any> {
    return this.http
      .delete(`${this.caminhoApi}/${id}`)
      .pipe(catchError(this.handleError));
  }

  inserirOuAtualizar(id: number, entidade: AlunoViewModel) : Observable<any> {
    if (id) {
      return this.http
        .put(`${this.caminhoApi}/${id}`, entidade)
        .pipe(catchError(this.handleError));
    } else {
      return this.http
        .post(this.caminhoApi, entidade)
        .pipe(catchError(this.handleError));
    }
  }

  private removeTrailingSlashes(url) {
    return url.replace(/\/+$/, '');
  }

    // Error handling
  handleError(error) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }

}
