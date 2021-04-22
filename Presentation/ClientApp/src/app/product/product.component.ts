import { Component } from '@angular/core';

@Component({
  selector: 'app-product-component',
  templateUrl: './product.component.html'
})
export class ProductComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
