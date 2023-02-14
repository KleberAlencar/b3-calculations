import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TaxDiscount } from '../models/TaxDiscount';

@Injectable()
export class CalculationService {
  baseURL = 'http://localhost:5000/api/calculations';

  constructor(private http: HttpClient) {}

  public getCdbCalcuation(investiment: number, monthsQuantity: number) {
    return this.http.get(
      `${this.baseURL}/cdb?Investiment=${investiment}&MonthsQuantity=${monthsQuantity}`
    );
  }

  public searchTaxDiscounts(): Observable<TaxDiscount[]> {
    return this.http.get<TaxDiscount[]>(`${this.baseURL}/tax-discounts`);
  }
}
