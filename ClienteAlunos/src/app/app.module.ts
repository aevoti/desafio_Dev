import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AlunosComponent } from './pages/alunos/alunos.component';
import { ListaAlunosComponent } from 'src/app/pages/alunos/components/lista-alunos/lista-alunos.component';
import { ModalExclusaoComponent } from 'src/app/pages/alunos/components/modal-exclusao/modal-exclusao.component';
import { AlunoService } from 'src/app/pages/alunos/services/aluno.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NgxPaginationModule } from 'ngx-pagination'; // <-- import the module

@NgModule({
  declarations: [
    AppComponent,
    AlunosComponent,
    ListaAlunosComponent,
    ModalExclusaoComponent
  ],
  imports: [
    BrowserModule,
    NgxPaginationModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    CommonModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [HttpClientModule, AlunoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
