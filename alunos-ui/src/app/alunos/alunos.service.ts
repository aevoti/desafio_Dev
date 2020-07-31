import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Aluno } from './aluno';
import { PaginatedList } from './paginated-list';
import { ApiResponse } from '../core/api-util/api-response';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class AlunosService {

    constructor(private http: HttpClient) { }

    getAll(filter: string = null, sortType: string = null, page = 0, pageSize = 10): Observable<PaginatedList<Aluno>> {
        let params = new HttpParams();
        params = params.set('page', page.toString());
        params = params.set('pageSize', pageSize.toString());

        if (filter)
            params = params.set('filter', filter);

        if (sortType)
            params = params.set('sortType', sortType);

        return this.http
            .get<ApiResponse>(`alunos`, { params: params })
            .pipe(map(res => res.data));
    }

    getById(id: number): Observable<Aluno> {
        return this.http
            .get<ApiResponse>(`alunos/${id}`)
            .pipe(map(res => res.data));
    }

    register(aluno: { email: string; none: string } | Aluno) {
        return this.http
            .post('alunos', aluno);
    }

    update(id: number, aluno: { email: string; none: string } | Aluno) {
        return this.http
            .put(`alunos/${id}`, { ...aluno, alunoId: id })
    }

    delete(id: number) {
        return this.http
            .delete(`alunos/${id}`)
    }
}