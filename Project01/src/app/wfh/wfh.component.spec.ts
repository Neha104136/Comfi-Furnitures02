import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WfhComponent } from './wfh.component';

describe('WfhComponent', () => {
  let component: WfhComponent;
  let fixture: ComponentFixture<WfhComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WfhComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WfhComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
