import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AlunosComponent } from './pages/alunos/alunos.component';
import { ListaAlunosComponent } from 'src/app/pages/alunos/components/lista-alunos/lista-alunos.component';
import { GerenciarAlunoComponent } from 'src/app/pages/alunos/components/gerenciar-aluno/gerenciar-aluno.component';
import { ModalExclusaoComponent } from 'src/app/pages/alunos/components/modal-exclusao/modal-exclusao.component';
import { AlunoService } from 'src/app/pages/alunos/services/aluno.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    AlunosComponent,
    ListaAlunosComponent,
    GerenciarAlunoComponent,
    ModalExclusaoComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [HttpClientModule, AlunoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
