import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddprojectmanagerComponent } from './addprojectmanager.component';

describe('AddprojectmanagerComponent', () => {
  let component: AddprojectmanagerComponent;
  let fixture: ComponentFixture<AddprojectmanagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddprojectmanagerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddprojectmanagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
