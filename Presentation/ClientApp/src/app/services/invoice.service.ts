import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Invoice } from '../models/invoice-detail.model';
import { InvoiceList } from '../models/invoice-list.model';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  baseUrl = environment.apiUrl + 'invoices';

  constructor(private http: HttpClient) { }

  getInvoices(): Observable<InvoiceList[]> {
    return this.http.get<InvoiceList[]>(this.baseUrl);
  }

  getInvoiceById(id: number): Observable<Invoice> {
    return this.http.get<Invoice>(`${this.baseUrl}/${id}`);
  }

  addInvoice(model: InvoiceList): Observable<InvoiceList> {
    return this.http.post<InvoiceList>(this.baseUrl, model);
  }

  deleteInvoice(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }

  updateInvoice(model: InvoiceList, id: number): Observable<InvoiceList> {
    return this.http.put<InvoiceList>(`${this.baseUrl}/${id}`, model);
  }
}


