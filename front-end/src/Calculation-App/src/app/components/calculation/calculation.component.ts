import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { CdbCalculation } from '../../models/CdbCalculation';
import { TaxDiscount } from '../../models/TaxDiscount';
import { CalculationService } from '../../services/calculation.service';


@Component({
  selector: 'app-calculation',
  templateUrl: './calculation.component.html',
  styleUrls: ['./calculation.component.scss']
})
export class CalculationComponent implements OnInit {

  investiment = new FormControl();
  months = new FormControl();

  public cdbCalculation: any;
  public taxDiscounts: TaxDiscount[] = [];

  constructor(
    private calculationService: CalculationService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {}

  public ngOnInit(): void {
    this.spinner.show();
    this.getCdbCalculation();
    this.searchTaxDiscounts();
  }

  public getCdbCalculation(): void {
    this.calculationService.getCdbCalcuation(this.investiment.value, this.months.value).subscribe(
      response => this.cdbCalculation = response,
      error => console.log(error)
    );
  }

  public searchTaxDiscounts(): void {
    this.calculationService.searchTaxDiscounts().subscribe({
      next: (_taxDiscounts: TaxDiscount[]) => {
        this.taxDiscounts = _taxDiscounts;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar lista de impostos', 'Error')
      },
      complete: () => this.spinner.hide()
    });
  }
}
