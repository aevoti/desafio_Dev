import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AlunosListComponent } from './pages/alunos/alunos-list/alunos-list.component';
import {InputTextModule} from 'primeng/inputtext';
import { TableCrudComponent } from './shared/components/table-crud/table-crud.component';
import {ToastModule} from 'primeng/toast';
import {DialogModule} from 'primeng/dialog';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import {DropdownModule} from 'primeng/dropdown';
import {TableModule} from 'primeng/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule }   from '@angular/forms';
import {ToolbarModule} from 'primeng/toolbar';

@NgModule({
  declarations: [
    AppComponent,
    AlunosListComponent,
    TableCrudComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,

    //primeng
    InputTextModule,
    ToastModule,
    DialogModule,
    ConfirmDialogModule,
    DropdownModule,
    TableModule,
    BrowserAnimationsModule,
    ToolbarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
