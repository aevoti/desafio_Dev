import { NgModule } from "@angular/core";

import { LayoutComponent } from "./pages/layout/layout.component";
import { FooterComponent } from "./components/footer/footer.component";
import { NavbarComponent } from "./components/navbar/navbar.component";

import { MaterialModule } from '../shared/modules';

@NgModule({
  declarations: [
    LayoutComponent,
    FooterComponent,
    NavbarComponent
  ],
  imports: [
    MaterialModule
  ],
  exports: [
    LayoutComponent
  ]
})
export class CoreModule {

}
