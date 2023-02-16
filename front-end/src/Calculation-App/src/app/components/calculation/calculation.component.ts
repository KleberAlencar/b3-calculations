import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { TaxDiscount } from '../../models/TaxDiscount';
import { CalculationService } from '../../services/calculation.service';

@Component({
  selector: 'app-calculation',
  templateUrl: './calculation.component.html',
  styleUrls: ['./calculation.component.scss']
})
export class CalculationComponent implements OnInit {

  formCalculation!: FormGroup;

  public cdbCalculation: any;
  public taxDiscounts: TaxDiscount[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private calculationService: CalculationService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {}

  public ngOnInit(): void {
    this.spinner.show();
    this.searchTaxDiscounts();

    this.formCalculation = this.formBuilder.group({
      txtInvestiment: [null, [Validators.required, Validators.min(1)]],
      txtMonths: [null, [Validators.required, Validators.min(2), Validators.max(1200)]]
    });
  }

  public getCdbCalculation(): void {
    this.calculationService.getCdbCalcuation(this.formCalculation.value.txtInvestiment, this.formCalculation.value.txtMonths).subscribe(
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
