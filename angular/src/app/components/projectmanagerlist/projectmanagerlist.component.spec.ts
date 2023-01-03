import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectmanagerlistComponent } from './projectmanagerlist.component';

describe('ProjectmanagerlistComponent', () => {
  let component: ProjectmanagerlistComponent;
  let fixture: ComponentFixture<ProjectmanagerlistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProjectmanagerlistComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProjectmanagerlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
