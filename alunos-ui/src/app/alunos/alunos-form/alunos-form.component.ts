import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AlunosService } from '../alunos.service';

@Component({
  selector: 'aln-alunos-form',
  templateUrl: './alunos-form.component.html',
  styleUrls: ['./alunos-form.component.scss']
})
export class AlunosFormComponent implements OnInit {

  pageTitle = "Novo Aluno"
  alunosForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private alunosService: AlunosService) { }

  ngOnInit(): void {
    this.alunosForm = this.formBuilder.group({
      nome: [
        '',
        [Validators.required, Validators.minLength(3), Validators.maxLength(100)]
      ],
      email: [
        '',
        [Validators.required, Validators.email]
      ],
    });
  }

  onSubmit() {
    this.alunosService
      .register(this.alunosForm.value)
      .subscribe(
        res => { console.log('REGISTERED'),
        err => { this.alunosForm.reset() } }
      );
  }
}
