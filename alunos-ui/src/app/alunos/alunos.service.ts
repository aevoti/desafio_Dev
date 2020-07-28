import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Aluno } from './aluno';

@Injectable({providedIn: 'root'})
export class AlunosService {

    constructor(private http: HttpClient) {}

    getAll() : Observable<Aluno[]> {
        return this.http
            .get<Aluno[]>('alunos');
    }
}