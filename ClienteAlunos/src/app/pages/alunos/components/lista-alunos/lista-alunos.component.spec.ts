import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaAlunosComponent } from './lista-alunos.component';

describe('ListaAlunosComponent', () => {
  let component: ListaAlunosComponent;
  let fixture: ComponentFixture<ListaAlunosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaAlunosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaAlunosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
