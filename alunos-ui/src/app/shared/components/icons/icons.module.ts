import { NgModule } from '@angular/core';

import { FeatherModule } from 'angular-feather';
import { ChevronDown, ChevronUp, Edit, Trash, Plus } from 'angular-feather/icons';

const icons = {
  ChevronDown,
  ChevronUp,
  Plus,
  Trash,
  Edit
};

@NgModule({
  imports: [
    FeatherModule.pick(icons)
  ],
  exports: [
    FeatherModule
  ]
})
export class IconsModule { }
