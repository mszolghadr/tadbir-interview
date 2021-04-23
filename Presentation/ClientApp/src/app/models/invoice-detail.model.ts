export class Invoice {
    id: number;
    userFullName: string;
    createdOnUtc: string;
    // serial: number;
    rows: InvoiceItem[];
}

export class InvoiceItem {
    productId: string;
    quantity: number;
    discountPercentage: number;
    productUnitPrice: number;
}

