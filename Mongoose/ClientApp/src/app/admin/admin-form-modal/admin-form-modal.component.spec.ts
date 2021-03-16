import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminFormModalComponent } from './admin-form-modal.component';

describe('AdminFormModalComponent', () => {
  let component: AdminFormModalComponent;
  let fixture: ComponentFixture<AdminFormModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminFormModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminFormModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
