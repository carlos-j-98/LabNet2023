import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableShippersComponent } from './table-shippers.component';

describe('TableShippersComponent', () => {
  let component: TableShippersComponent;
  let fixture: ComponentFixture<TableShippersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableShippersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TableShippersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
