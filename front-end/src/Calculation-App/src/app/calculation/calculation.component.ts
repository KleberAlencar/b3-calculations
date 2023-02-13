import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-calculation',
  templateUrl: './calculation.component.html',
  styleUrls: ['./calculation.component.scss']
})
export class CalculationComponent implements OnInit {

  public cdbCalculation: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getCdbCalculation();
  }

  // teste
  public getCdbCalculation(): void {
    this.http.get('http://localhost:5000/api/calculations/cdb?Investiment=1000&MonthsQuantity=6').subscribe(
      response => this.cdbCalculation = response,
      error => console.log(error)
    );
  }
}
