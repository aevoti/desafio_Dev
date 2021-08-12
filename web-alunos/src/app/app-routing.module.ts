import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlunosListComponent } from './pages/alunos/alunos-list/alunos-list.component';

const routes: Routes = [
  {
    path: '',
    canActivateChild: [], children: [
      // { path: 'login', component: LoginComponent },
      { path: 'alunos', component: AlunosListComponent },
      {
        path: '**', redirectTo: 'alunos', pathMatch: 'full'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
