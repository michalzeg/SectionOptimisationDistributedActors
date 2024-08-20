import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PopulationHeaderComponent } from './population-header.component';

describe('PopulationHeaderComponent', () => {
  let component: PopulationHeaderComponent;
  let fixture: ComponentFixture<PopulationHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PopulationHeaderComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PopulationHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
