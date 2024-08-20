import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TerminationHeaderComponent } from './termination-header.component';

describe('TerminationHeaderComponent', () => {
  let component: TerminationHeaderComponent;
  let fixture: ComponentFixture<TerminationHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TerminationHeaderComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TerminationHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
