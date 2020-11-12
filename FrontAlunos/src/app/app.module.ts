import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AlunoComponent } from './aluno/aluno.component';
import { AlunoService } from './services/aluno.service';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatButtonModule} from '@angular/material/button';
import {MatMenuModule       } from '@angular/material/menu';
import {MatDatepickerModule } from '@angular/material/datepicker';
import {MatNativeDateModule } from '@angular/material/core';
import {MatIconModule       } from '@angular/material/icon';
import {MatCardModule       } from '@angular/material/card';
import {MatSidenavModule    } from '@angular/material/sidenav';
import {MatFormFieldModule  } from '@angular/material/form-field';
import {MatInputModule      } from '@angular/material/input';
import {MatTooltipModule    } from '@angular/material/tooltip';
import {MatToolbarModule    } from '@angular/material/toolbar';


import { MatRadioModule } from '@angular/material/radio';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import { OrderModule } from 'ngx-order-pipe';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
  declarations: [
    AppComponent,
    AlunoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatMenuModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatRadioModule,
    MatCardModule,
    MatSidenavModule,
    MatFormFieldModule,
    MatInputModule,
    MatTooltipModule,
    MatToolbarModule,
    OrderModule,
    FlexLayoutModule
  ],
  providers: [AlunoService, HttpClientModule, MatDatepickerModule, MatIconModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
