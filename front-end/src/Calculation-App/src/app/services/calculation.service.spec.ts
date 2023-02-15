/* tslint:disable:no-unused-variable */
import { TestBed } from '@angular/core/testing';
import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';

import { CalculationService } from './calculation.service';
import { MOCK_DATA_CALCULATION, MOCK_DATA_DISCOUNTS } from './calculation.service.mock-data';

describe('CalculationService', () => {
  let httpTestingController: HttpTestingController;
  let service: CalculationService;
  let investiment: 1000.00;
  let months: 3;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CalculationService],
    });

    httpTestingController = TestBed.inject(HttpTestingController);

    service = TestBed.inject(CalculationService);
  });

  afterEach(() => {
    httpTestingController.verify();
  })

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should fetch a calculation', (done) => {
    service = TestBed.inject(CalculationService);

    service.getCdbCalcuation(investiment, months).subscribe(data => {
      expect(data).toEqual(MOCK_DATA_CALCULATION.cdbCalculation);
      done();
    });

    const testRequest = httpTestingController.expectOne(`http://localhost:5000/api/calculations/cdb?Investiment=${investiment}&MonthsQuantity=${months}`);

    testRequest.flush(MOCK_DATA_CALCULATION.cdbCalculation);
  });

  it('shoult fetch a list of tax discounts', (done) => {
    service = TestBed.inject(CalculationService);

    service.searchTaxDiscounts().subscribe(data => {
      expect(data).toEqual(MOCK_DATA_DISCOUNTS.discounts);
      done();
    });

    const testRequest = httpTestingController.expectOne(`http://localhost:5000/api/calculations/tax-discounts`);

    testRequest.flush(MOCK_DATA_DISCOUNTS.discounts);
  });

});
