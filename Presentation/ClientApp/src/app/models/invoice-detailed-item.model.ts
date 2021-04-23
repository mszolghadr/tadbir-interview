export class InvoiceDetailedItem {
    constructor(private quantity: number, private discountPercentage: number, private productUnitPrice: number) { }

    get discountedUnitPrice(): number { return this.productUnitPrice * (100 - this.discountPercentage) / 100; }
    get unitDiscountAmount(): number { return this.productUnitPrice * this.discountPercentage / 100; }
    get totalPrice(): number { return this.productUnitPrice * this.quantity; }
    get totalDiscountedPrice(): number { return this.quantity * this.discountedUnitPrice; }
    get totalDiscountAmount(): number { return this.unitDiscountAmount * this.quantity; }
}
