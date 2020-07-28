import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatButtonModule } from '@angular/material/button';

import { IconsModule } from './components/icons/icons.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatButtonModule,
    IconsModule
  ],
  exports: [
    MatButtonModule,
    IconsModule
  ]
})
export class SharedModule { }
