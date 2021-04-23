import { KeyValue } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { resourceUsage } from 'process';
import { InvoiceItem } from '../../models/invoice-detail.model';
import { InvoiceDetailedItem } from '../../models/invoice-detailed-item.model';
import { InvoiceList } from '../../models/invoice-list.model';
import { InvoiceService } from '../../services/invoice.service';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-invoice-detail',
  templateUrl: './invoice-detail.component.html',
  styleUrls: ['./invoice-detail.component.css']
})
export class InvoiceDetailComponent implements OnInit {

  @Input() model: InvoiceList;
  @Input() mode = 'NEW';
  invoiceForm: FormGroup = new FormGroup({});
  productList: KeyValue<number, string>[] = [];
  date = new Date(Date.now()).toLocaleDateString('fa-IR');

  constructor(
    private fb: FormBuilder,
    private invoiceService: InvoiceService,
    private productService: ProductService,
    public activeModal: NgbActiveModal
  ) {
    this.invoiceForm = fb.group({
      id: [{ value: null, disabled: true }],
      userFullName: [, [Validators.required]],
      createdOnUtc: [{ value: null, disabled: true }],
      description: [],
      rows: fb.array([this.newRow()])
    });
    productService.productDropDown().subscribe(result => this.productList = result);
  }

  get invoiceItems(): FormArray { return this.invoiceForm.controls.rows as FormArray; }

  newRow(data?) {
    const g = this.fb.group({
      productId: [, [Validators.required]],
      quantity: [1, [Validators.required, Validators.min(1)]],
      discountPercentage: [, [Validators.required]],
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
    if (this.mode !== 'NEW') {
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

    if (this.mode === 'VIEW') {
      this.invoiceForm.disable();
    }
  }

  getDetail(control: AbstractControl) {
    return new InvoiceDetailedItem(
      control.getValue('quantity'),
      control.getValue('discountPercentage'),
      control.getValue('productUnitPrice'));
  }

  add(): void {
    this.invoiceItems.push(this.newRow());
  }

  del(index: number): void {
    this.invoiceItems.removeAt(index);
  }

  submit(): void {
    const id = this.invoiceForm.getValue('id');
    if (id) {
      this.invoiceService.updateInvoice(this.invoiceForm.value, id).subscribe(result => this.activeModal.close(result));
    } else {
      this.invoiceService.addInvoice(this.invoiceForm.value).subscribe(result => this.activeModal.close(result));
    }
  }

  get totalPrice() {
    return this.invoiceItems.controls.map(c => this.getDetail(c)).reduce((pre, curr) => pre + curr.totalPrice, 0);
  }

  get totalDiscountAmount() {
    return this.invoiceItems.controls.map(c => this.getDetail(c)).reduce((pre, curr) => pre + curr.totalDiscountAmount, 0);
  }

  get totalDiscountedPrice() {
    return this.invoiceItems.controls.map(c => this.getDetail(c)).reduce((pre, curr) => pre + curr.totalDiscountedPrice, 0);
  }

  get isReadOnly(): boolean { return this.mode === 'VIEW'; }

  changeProduct(event, index: number): void {
    const prodId = event.target.value;
    const oldProd: InvoiceItem = this.invoiceItems.getRawValue()[index];
    this.productService.getProductById(prodId).subscribe(result => {
      oldProd.productId = prodId;
      oldProd.productUnitPrice = result.unitPrice;
      this.invoiceItems.controls[index].patchValue(oldProd);
    });
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
