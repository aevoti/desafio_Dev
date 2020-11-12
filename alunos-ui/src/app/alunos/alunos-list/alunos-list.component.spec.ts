import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlunosListComponent } from './alunos-list.component';

describe('AlunosListComponent', () => {
  let component: AlunosListComponent;
  let fixture: ComponentFixture<AlunosListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlunosListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlunosListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
