import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-calculation',
  templateUrl: './calculation.component.html',
  styleUrls: ['./calculation.component.scss']
})
export class CalculationComponent implements OnInit {

  public cdbCalculation: any = [];
  public taxDiscounts: any = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getCdbCalculation();
    this.searchTaxDiscounts();
  }

  public getCdbCalculation(): void {
    this.http.get('http://localhost:5000/api/calculations/cdb?Investiment=1000&MonthsQuantity=10').subscribe(
      response => this.cdbCalculation = response,
      error => console.log(error)
    );
  }

  public searchTaxDiscounts(): void {
    this.http.get('http://localhost:5000/api/calculations/tax-discounts').subscribe(
      response => this.taxDiscounts = response,
      error => console.log(error)
    );
  }
}
