import { of } from "rxjs";
import { MOCK_DATA_CALCULATION } from "./calculation.service.mock-data";
import { MOCK_DATA_DISCOUNTS } from "./calculation.service.mock-data";

export class ApiServiceStub {
  getCdbCalcuation()
  {
    return of(MOCK_DATA_CALCULATION);
  }

  searchTaxDiscounts()
  {
    return of(MOCK_DATA_DISCOUNTS);
  }
}

