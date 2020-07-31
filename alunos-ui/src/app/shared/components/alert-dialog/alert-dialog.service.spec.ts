import { TestBed } from '@angular/core/testing';

import { AlertDialogService } from './alert-dialog.service';

describe('AlertDialogService', () => {
  let service: AlertDialogService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AlertDialogService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
