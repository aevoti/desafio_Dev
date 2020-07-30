import { NgModule } from "@angular/core";

import { AlunoComponent } from "./page/aluno.component";
import { MaterialModule } from '../shared/modules';

@NgModule({
  declarations: [
    AlunoComponent
  ],
  imports: [
    MaterialModule
  ],
  exports: [
    AlunoComponent
  ]
})
export class AlunoModule {

}
