import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from 'src/app/models/Student';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  url = `${environment.urlBase}/api/alunos`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Student[]> {
    return this.http.get<Student[]>(this.url)
  }

  post(student: Student) {
    return this.http.post(this.url, student)
  }

  put(student: Student) {
    return this.http.put(`${this.url}/${student.alunoId}`, student)
  }

  delete(id:number ) {
    return this.http.delete(`${this.url}/${id}`)
  }

}
