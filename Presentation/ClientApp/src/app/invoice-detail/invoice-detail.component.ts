import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { InvoiceItem } from '../models/invoice-detail.model';
import { InvoiceDetailedItem } from '../models/invoice-detailed-item.model';
import { InvoiceList } from '../models/invoice-list.model';
import { InvoiceService } from '../services/invoice.service';

@Component({
  selector: 'app-invoice-detail',
  templateUrl: './invoice-detail.component.html',
  styleUrls: ['./invoice-detail.component.css']
})
export class InvoiceDetailComponent implements OnInit {

  @Input() model: InvoiceList;
  invoiceForm: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder, private invoiceService: InvoiceService) {
    this.invoiceForm = fb.group({
      id: [],
      userFullName: [],
      createdOnUtc: [],
      description: [],
      rows: fb.array([this.newRow()])
    });
  }

  get invoiceItems(): FormArray { return this.invoiceForm.controls.rows as FormArray; }

  newRow(data?) {
    const g = this.fb.group({
      productId: [],
      quantity: [],
      discountPercentage: [],
      productUnitPrice: [{ value: 0, disabled: true }]
    });

    if (data) {
      g.patchValue(data);
      // g.get('productUnitPrice').disable();
    }
    return g;
  }

  ngOnInit(): void {
    this.invoiceForm.patchValue(this.model);
    this.invoiceService.getInvoiceById(this.model.id).subscribe(result => {
      this.invoiceForm.patchValue(result);

      this.invoiceItems.clear();
      if (result.rows && result.rows.length) {
        result.rows.forEach(r => {
          this.invoiceItems.push(this.newRow(r));
        });
      }
    });
  }

  getDetail(control: AbstractControl) {
    return new InvoiceDetailedItem(
      control.getValue('quantity'),
      control.getValue('discountPercentage'),
      control.getValue('productUnitPrice'));
  }
}

declare module '@angular/forms' {
  export interface AbstractControl {
    getControl(controlName: string): FormControl;
    getValue(controlName: string): any;
  }
}

AbstractControl.prototype.getControl = function (controlName: string) {
  const _self = this as AbstractControl;
  return _self.get(controlName) as FormControl;
};

AbstractControl.prototype.getValue = function (controlName: string) {
  const _self = this as AbstractControl;
  return _self.get(controlName).value;
};
