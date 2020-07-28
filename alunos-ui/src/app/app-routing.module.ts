import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BaseLayoutComponent } from './base-layout/base-layout.component';
import { AlunosListComponent } from './alunos/alunos-list/alunos-list.component';
import { AlunosFormComponent } from './alunos/alunos-form/alunos-form.component';


const routes: Routes = [
  {
    path: '',
    component: BaseLayoutComponent,
    children: [
      {
        path: '',
        redirectTo: 'alunos',
        pathMatch: 'full'
      },
      {
        path: 'alunos',
        component: AlunosListComponent
      },
      {
        path: 'alunos/new',
        component: AlunosFormComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
