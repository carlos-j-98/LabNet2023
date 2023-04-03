import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { ShippersService } from 'src/app/services/shippers/shippers.service';
import { Shippers } from '../../shippers-models/Shippers';
import { ShareDataService } from 'src/app/services/share-Data/share-data.service';
import { NotifyComponent } from '../notify/notify.component';

@Component({
  selector: 'app-form-shippers',
  templateUrl: './form-shippers.component.html',
  styleUrls: ['./form-shippers.component.scss']
})
export class FormShippersComponent implements OnInit {
  form!: FormGroup;
  shippers: Shippers[] = [];
  selectedShipper!: Shippers;
  isNewShipper = false;
  id: string = "new";

  constructor(private fb: FormBuilder, private shareService: ShareDataService, private shipService: ShippersService, private notify: NotifyComponent) {
  }

  ngOnInit(): void {

    this.form = this.fb.group({
      name: [null, [Validators.required, Validators.maxLength(40)]],
      phone: [null, [Validators.maxLength(24)]],
      shipper: [null, Validators.required],
    });
    this.onShipperSelect(this.id);
    this.servicesSuscribe();
  }
  get control(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }
  servicesSuscribe() {
    this.shipService.getShippers().subscribe((response: Shippers[]) => {
      this.loadShippers(response);
    });
    this.shareService.id$.subscribe(id => {
      this.id = id;
      this.onShipperSelect(id);
    });
    this.shipService.shippers$.subscribe({
      next: (response: Shippers[]) =>{
        this.shippers = response;
        this.loadShippers(response);
      },
      error: (error) =>{
        this.shipService.updateShippersList();
      }
    });
  }
  loadShippers(ship: Shippers[]) {
    this.shippers = [];
    this.shippers = this.shippers.concat(ship);
    this.onShipperSelect("new");
  }
  onSubmit(): void {
    if (this.form.valid) {
      let ship = new Shippers();
      ship.ID = this.form.value.shipper;
      ship.CompanyName = this.form.value.name;
      ship.Phone = this.form.value.phone;
      if (this.isNewShipper) {
        this.shipService.createShippers(ship).subscribe({
          next: response => {
            this.notify.showSuccess("El Shipper fue agregado con exito ");
            this.shipService.updateShippersList();
          },
          error: (error) => {
            this.notify.showError(error);
          },
        });
      } else {
        this.shipService.updateShipper(ship).subscribe({
          next: response => {
            this.notify.showSuccess("El Shipper fue actualizado con exito ");
            this.shipService.updateShippersList();
          },
          error: (error) => {
            this.notify.showError(error);
          },
        });
      }
      this.onShipperSelect("new");
    }
  }
  onShipperSelect(event: string): void {
    let shipperId = "0";
    if (event === "new") {
      shipperId = event;
      this.isNewShipper = true;
      this.form.patchValue({
        name: null,
        phone: null,
        shipper: "new"
      });
      return;
    } else {
      shipperId = event;
      this.isNewShipper = false;
    }
    this.shipService.getShippersId(parseInt(shipperId)).subscribe((shipper) => {
      this.selectedShipper = shipper.data;
      this.form.patchValue({
        name: shipper.data.CompanyName,
        phone: shipper.data.Phone,
        shipper: shipper.data.ID
      });
    });
  }
}
