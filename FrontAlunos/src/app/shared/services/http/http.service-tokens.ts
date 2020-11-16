import { HttpClient } from '@angular/common/http';
import { InjectionToken, inject } from '@angular/core';
import { HttpService } from './http.service';
import { Aluno } from '../../models/aluno.model';

export const ALUNO_SERVICE = new InjectionToken<HttpService<Aluno>>('AlunoService', {
  providedIn: 'root',
  factory: () => new HttpService<Aluno>('/api/alunos', inject(HttpClient))
})
