import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Aluno } from './aluno';

@Injectable({ providedIn: 'root' })
export class AlunosService {

    constructor(private http: HttpClient) { }

    getAll(): Observable<Aluno[]> {
        return this.http
            .get<Aluno[]>('alunos');
    }

    getById(id: number): Observable<Aluno> {
        return this.http
            .get<Aluno>(`alunos/${id}`);
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