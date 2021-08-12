import { HttpClient, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AlunosModel } from '../models/alunos.model';

@Injectable({
    providedIn: 'root'
})

export class AlunosService {
    constructor(private httpClient: HttpClient) { }
    url = 'https://localhost:5001/api/Alunos';

    getAll() {
        return this.httpClient.get<AlunosModel[]>(this.url);
    }

    insert(alunosModel: AlunosModel): Observable<AlunosModel> {
        return this.httpClient.post<AlunosModel>(this.url, alunosModel);
    }

    change(alunosModel: AlunosModel): Observable<AlunosModel> {
        return this.httpClient.put<AlunosModel>(`${this.url}/${alunosModel.alunoId}`, alunosModel);
    }

    delete(id: number): Observable<void> {
        return this.httpClient.delete<void>(`${this.url}/${id}`);
    }
}