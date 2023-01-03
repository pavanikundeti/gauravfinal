import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectmanagerdetailsComponent } from './projectmanagerdetails.component';

describe('ProjectmanagerdetailsComponent', () => {
  let component: ProjectmanagerdetailsComponent;
  let fixture: ComponentFixture<ProjectmanagerdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProjectmanagerdetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProjectmanagerdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
