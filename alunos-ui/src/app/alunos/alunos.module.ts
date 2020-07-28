import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { AlunosListComponent } from './alunos-list/alunos-list.component';
import { SharedModule } from "src/app/shared/shared.module";
import { AlunosFormComponent } from './alunos-form/alunos-form.component';


@NgModule({
  declarations: [AlunosListComponent, AlunosFormComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule
  ]
})
export class AlunosModule { }
