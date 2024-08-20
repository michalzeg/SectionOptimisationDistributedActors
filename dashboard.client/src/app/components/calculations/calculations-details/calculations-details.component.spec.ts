import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculationsDetailsComponent } from './calculations-details.component';

describe('CalculationsDetailsComponent', () => {
  let component: CalculationsDetailsComponent;
  let fixture: ComponentFixture<CalculationsDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CalculationsDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CalculationsDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
