import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-component',
  templateUrl: './product.component.html',
  styles: ["td:last-child{width: 6rem}"]
})
export class ProductComponent {
  public products: Product[];
  public form: FormGroup;
  /**
   *
   */
  constructor(private productService: ProductService, private fb: FormBuilder) {
    productService.getInvoices().subscribe(result => this.products = result);

    this.form = fb.group({
      id: [0],
      title: [, [Validators.required]],
      unitPrice: [, [Validators.required, Validators.min(1)]]
    })
  }

  public save() {
    const id = this.form.value?.id;
    if (id) {
      this.productService.updateInvoice(this.form.value, id).subscribe(result => {
        const index = this.products.findIndex(p => p.id == id);
        this.products[index] = result;
        this.resetForm();
      }, error => this.showError(error));
    } else {
      this.productService.addInvoice(this.form.value).subscribe(
        result => {
          this.products.push(result);
          this.resetForm();
        },
        error => this.showError(error)
      );
    }
  }

  public edit(item: Product) {
    this.form.patchValue(item);
  }

  del(id) {
    if (confirm("از حذف این کالا مطمئن هستید؟"))
      this.productService.deleteInvoice(id).subscribe(() => {
        this.products = this.products.filter(p => p.id != id);
      }
        , error => this.showError(error));
  }

  resetForm(): void {
    this.form.reset({ id: 0 });
  }

  showError(error: any) { }
}
