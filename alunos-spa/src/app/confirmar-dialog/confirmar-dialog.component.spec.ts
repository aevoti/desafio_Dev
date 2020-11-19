import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmarDialogComponent } from './confirmar-dialog.component';

describe('ConfirmarDialogComponent', () => {
  let component: ConfirmarDialogComponent;
  let fixture: ComponentFixture<ConfirmarDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConfirmarDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmarDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
