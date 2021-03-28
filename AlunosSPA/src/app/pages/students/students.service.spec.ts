/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { StudentsService } from './students.service';

describe('Service: Students', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [StudentsService]
    });
  });

  it('should ...', inject([StudentsService], (service: StudentsService) => {
    expect(service).toBeTruthy();
  }));
});
