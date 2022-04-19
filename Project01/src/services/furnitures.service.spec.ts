import { TestBed } from '@angular/core/testing';

import { furnituresService } from './furnitures.service';

describe('FurnituresService', () => {
  let service: furnituresService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(furnituresService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
