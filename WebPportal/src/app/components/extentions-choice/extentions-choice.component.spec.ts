import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExtentionsChoiceComponent } from './extentions-choice.component';

describe('ExtentionsChoiceComponent', () => {
  let component: ExtentionsChoiceComponent;
  let fixture: ComponentFixture<ExtentionsChoiceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExtentionsChoiceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExtentionsChoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
