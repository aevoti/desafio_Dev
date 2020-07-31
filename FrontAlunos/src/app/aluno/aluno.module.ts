import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from '@angular/forms';

import { AlunoComponent } from "./page/aluno.component";
import { DeleteDialogComponent } from './components/delete-dialog/delete-dialog.component'

import { MaterialModule } from '../shared/modules';
import { CommonModule } from '@angular/common';


@NgModule({
  declarations: [
    AlunoComponent,
    DeleteDialogComponent
  ],
  entryComponents: [
    DeleteDialogComponent
  ],
  imports: [
    MaterialModule,
    ReactiveFormsModule,
    CommonModule
  ],
  exports: [
    AlunoComponent
  ]
})
export class AlunoModule {

}
