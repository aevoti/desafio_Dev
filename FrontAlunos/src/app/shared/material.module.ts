import { NgModule } from '@angular/core';

import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  imports: [
    MatIconModule,
    MatTableModule
  ],
  exports: [
    MatIconModule,
    MatTableModule
  ]
})
export class MaterialModule { }
