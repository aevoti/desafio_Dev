import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AlunosComponent } from './alunos/alunos.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  { path: '',   redirectTo: '/alunos', pathMatch: 'full' },
  { path: 'alunos', component: AlunosComponent },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
