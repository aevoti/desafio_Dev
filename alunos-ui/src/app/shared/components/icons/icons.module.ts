import { NgModule } from '@angular/core';

import { FeatherModule } from 'angular-feather';
import { ArrowDown, ArrowUp, Edit, Trash, Plus, ArrowLeft, Search, ChevronLeft, ChevronRight, ChevronsLeft, ChevronsRight } from 'angular-feather/icons';

const icons = {
  ArrowDown,
  ArrowUp,
  Plus,
  Trash,
  Edit,
  ArrowLeft,
  Search,
  ChevronLeft,
  ChevronRight,
  ChevronsLeft, 
  ChevronsRight
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
