import { MonthlyCalculation } from "./MonthlyCalculation";

export interface CdbCalculation {
  investiment: number;
  grossIncome: number;
  netIncome: number;
  taxDiscountValue: number;
  totalGrossInvestmentValue: number;
  totalNetInvestmentValue: number;
  monthlyCalculations: MonthlyCalculation[];
}
