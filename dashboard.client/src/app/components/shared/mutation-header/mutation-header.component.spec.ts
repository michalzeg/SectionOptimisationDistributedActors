import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MutationHeaderComponent } from './mutation-header.component';

describe('MutationHeaderComponent', () => {
  let component: MutationHeaderComponent;
  let fixture: ComponentFixture<MutationHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MutationHeaderComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MutationHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
