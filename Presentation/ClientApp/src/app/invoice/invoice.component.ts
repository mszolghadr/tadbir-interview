import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Invoice } from '../models/invoice.model';
import { InvoiceService } from '../services/invoice.service';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html'
})
export class FetchDataComponent {
  invoices: Invoice[] = [];
  page = 1;
  pageSize = 10;

  constructor(
    private invoiceService: InvoiceService,
    private modalService: NgbModal
  ) {
    invoiceService.getInvoices().subscribe(result => this.invoices = result);
  }
}
