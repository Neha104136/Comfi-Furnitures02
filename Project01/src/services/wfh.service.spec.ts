import { TestBed } from '@angular/core/testing';

import { WfhService } from './wfh.service';

describe('WfhService', () => {
  let service: WfhService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WfhService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
