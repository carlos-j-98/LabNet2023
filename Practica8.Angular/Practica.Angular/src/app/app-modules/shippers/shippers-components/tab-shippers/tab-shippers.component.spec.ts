import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TabShippersComponent } from './tab-shippers.component';

describe('TabShippersComponent', () => {
  let component: TabShippersComponent;
  let fixture: ComponentFixture<TabShippersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TabShippersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TabShippersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
