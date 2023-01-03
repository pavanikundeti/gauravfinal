import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditprojectmanagerComponent } from './editprojectmanager.component';

describe('EditprojectmanagerComponent', () => {
  let component: EditprojectmanagerComponent;
  let fixture: ComponentFixture<EditprojectmanagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditprojectmanagerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditprojectmanagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
