import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PcListComponentComponent } from './pc-list-component.component';

describe('PcListComponentComponent', () => {
  let component: PcListComponentComponent;
  let fixture: ComponentFixture<PcListComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PcListComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PcListComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
