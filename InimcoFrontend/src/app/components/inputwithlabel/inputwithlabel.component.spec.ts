import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImputWithLabelComponent } from './inputwithlabel.component';

describe('InputwithlabelComponent', () => {
  let component: ImputWithLabelComponent;
  let fixture: ComponentFixture<ImputWithLabelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImputWithLabelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImputWithLabelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
