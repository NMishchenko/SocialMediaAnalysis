import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostAnalyticsComponent } from './post-analytics.component';

describe('PostAnalyticsComponent', () => {
  let component: PostAnalyticsComponent;
  let fixture: ComponentFixture<PostAnalyticsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PostAnalyticsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PostAnalyticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
