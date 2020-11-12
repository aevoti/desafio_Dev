import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule, MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

import { IconsModule } from './components/icons/icons.module';
import { MAT_FORM_FIELD_OUTLINE_APPEARANCE } from './util/material-design.config';
import { SearchInputComponent } from './components/search-input/search-input.component';
import { SortBtnComponent } from './components/sort-btn/sort-btn.component';
import { PaginatorComponent } from './components/paginator/paginator.component';
import { AlertDialogComponent } from './components/alert-dialog/alert-dialog.component';

@NgModule({
  declarations: [
    SearchInputComponent, 
    SortBtnComponent, 
    PaginatorComponent, 
    AlertDialogComponent
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    IconsModule,
    MatDialogModule
  ],
  exports: [
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    IconsModule,
    MatDialogModule,

    SearchInputComponent,
    SortBtnComponent,
    PaginatorComponent,
    AlertDialogComponent
  ],
  providers: [
    {
      provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
      useValue: MAT_FORM_FIELD_OUTLINE_APPEARANCE
    },
  ]
})
export class SharedModule { }
