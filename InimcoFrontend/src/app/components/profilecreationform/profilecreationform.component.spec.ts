import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfilecreationformComponent } from './profilecreationform.component';

describe('ProfilecreationformComponent', () => {
  let component: ProfilecreationformComponent;
  let fixture: ComponentFixture<ProfilecreationformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfilecreationformComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfilecreationformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
