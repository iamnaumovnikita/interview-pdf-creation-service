import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintMapComponent } from './print-map.component';

describe('PrintMapComponent', () => {
  let component: PrintMapComponent;
  let fixture: ComponentFixture<PrintMapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrintMapComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
