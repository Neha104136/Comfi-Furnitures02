import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FurnituresComponent } from './furnitures.component';

describe('FurnituresComponent', () => {
  let component: FurnituresComponent;
  let fixture: ComponentFixture<FurnituresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FurnituresComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FurnituresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
