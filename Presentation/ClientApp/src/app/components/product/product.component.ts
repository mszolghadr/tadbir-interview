import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Product } from '../../models/product.model';
import { ToastMessage } from '../../models/toast.model';
import { ProductService } from '../../services/product.service';
import { ToastService } from '../../services/toast.service';
import { ConfirmModalComponent } from '../../shared/confirm-modal.component';

@Component({
  selector: 'app-product-component',
  templateUrl: './product.component.html',
  styles: ['td:last-child{width: 6rem}']
})
export class ProductComponent {
  products: Product[] = [];
  form: FormGroup;
  page = 1;
  pageSize = 10;
  /**
   *
   */
  constructor(
    private productService: ProductService,
    private fb: FormBuilder,
    private toastService: ToastService,
    private modalService: NgbModal
  ) {
    productService.getProducts().subscribe(result => this.products = result);

    this.form = fb.group({
      id: [0],
      title: [, [Validators.required]],
      unitPrice: [, [Validators.required, Validators.min(1)]]
    });
  }

  save() {
    const id = this.form.value?.id;
    if (id) {
      this.productService.updateProduct(this.form.value, id).subscribe(result => {
        const index = this.products.findIndex(p => p.id === id);
        this.products[index] = result;
        this.resetForm();
      }, error => this.showError(error));
    } else {
      this.productService.addProduct(this.form.value).subscribe(
        result => {
          this.products.push(result);
          this.resetForm();
        },
        error => this.showError(error)
      );
    }
  }

  edit(item: Product) {
    this.form.patchValue(item);
  }

  del(id) {
    const modalRef = this.modalService.open(ConfirmModalComponent);
    modalRef.componentInstance.message = 'از حذف این کالا مطمئن هستید؟';
    modalRef.result.then((result) => {
      if (result === 'YES') {
        this.productService.deleteProduct(id).subscribe({
          next: () => {
            this.products = this.products.filter(p => p.id !== id);
          }
          , error: error => this.showError(error)
        });
      }
    }, () => { });
  }

  resetForm(): void {
    this.form.reset({ id: 0 });
  }

  showError(error: any) {
    this.toastService.showDanger(error.error.title ?? error.error);
  }
}
