import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GerenciarAlunoComponent } from './gerenciar-aluno.component';

describe('GerenciarAlunoComponent', () => {
  let component: GerenciarAlunoComponent;
  let fixture: ComponentFixture<GerenciarAlunoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GerenciarAlunoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GerenciarAlunoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
