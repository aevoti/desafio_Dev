import { NgModule } from '@angular/core';

import { FeatherModule } from 'angular-feather';
import { ChevronDown, ChevronUp, Edit, Trash, Plus, ArrowLeft, Search } from 'angular-feather/icons';

const icons = {
  ChevronDown,
  ChevronUp,
  Plus,
  Trash,
  Edit,
  ArrowLeft,
  Search
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
