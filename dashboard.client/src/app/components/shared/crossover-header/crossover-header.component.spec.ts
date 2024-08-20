import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrossoverHeaderComponent } from './crossover-header.component';

describe('CrossoverHeaderComponent', () => {
  let component: CrossoverHeaderComponent;
  let fixture: ComponentFixture<CrossoverHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrossoverHeaderComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CrossoverHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
