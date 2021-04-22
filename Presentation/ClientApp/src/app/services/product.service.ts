import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {


  baseUrl = environment.apiUrl + 'products';

  constructor(private http: HttpClient) { }

  getInvoices(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl);
  }

  addInvoice(model: Product): Observable<Product> {
    return this.http.post<Product>(this.baseUrl, model);
  }

  deleteInvoice(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }

  updateInvoice(model: Product, id: number): Observable<Product> {
    return this.http.put<Product>(`${this.baseUrl}/${id}`, model);
  }
}
