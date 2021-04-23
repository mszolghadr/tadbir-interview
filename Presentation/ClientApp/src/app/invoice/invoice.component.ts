import { Component } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { InvoiceDetailComponent } from '../invoice-detail/invoice-detail.component';
import { InvoiceList } from '../models/invoice-list.model';
import { InvoiceService } from '../services/invoice.service';
import { ToastService } from '../services/toast.service';
import { ConfirmModalComponent } from '../shared/confirm-modal.component';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html'
})
export class FetchDataComponent {
  invoices: InvoiceList[] = [];
  page = 1;
  pageSize = 10;

  constructor(
    private invoiceService: InvoiceService,
    private toastService: ToastService,
    config: NgbModalConfig,
    private modalService: NgbModal
  ) {
    invoiceService.getInvoices().subscribe(result => this.invoices = result);
    config.size = 'xl';
  }

  edit(invoice: InvoiceList) {
    const modalRef = this.modalService.open(InvoiceDetailComponent);
    modalRef.componentInstance.model = invoice;
  }

  del(id: number) {
    const modalRef = this.modalService.open(ConfirmModalComponent);
    modalRef.componentInstance.message = 'از حذف این فاکتور مطمئن هستید؟';
    modalRef.result.then((result) => {
      if (result === 'YES') {
        this.invoiceService.deleteInvoice(id).subscribe({
          next: () => {
            this.invoices = this.invoices.filter(p => p.id !== id);
          }
          , error: error => this.showError(error)
        });
      }
    }, () => { });
  }

  showError(error: any) {
    this.toastService.showDanger(error.error.title ?? error.error);
  }
}
