import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlunosDetailsComponent } from './alunos-details.component';

describe('AlunosDetailsComponent', () => {
  let component: AlunosDetailsComponent;
  let fixture: ComponentFixture<AlunosDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlunosDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AlunosDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
