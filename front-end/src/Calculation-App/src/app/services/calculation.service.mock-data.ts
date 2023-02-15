export type CdbCalculation = {
  investiment: number;
  grossIncome: number;
  netIncome: number;
  taxDiscountValue: number;
  totalGrossInvestmentValue: number;
  totalNetInvestmentValue: number;
  monthlyCalculations: [
    {
      month: number;
      initialValue: number;
      finalValue: number;
      grossIncome: number;
    }
  ];
};

export const MOCK_DATA_CALCULATION = {
  cdbCalculation: {
    investiment: 1000,
    grossIncome: 29.44,
    netIncome: 22.82,
    taxDiscountValue: 6.62,
    totalGrossInvestmentValue: 1029.44,
    totalNetInvestmentValue: 1022.82,
    monthlyCalculations: [
      {
        month: 1,
        initialValue: 1000,
        finalValue: 1009.72,
        grossIncome: 9.72,
      },
      {
        month: 2,
        initialValue: 1009.72,
        finalValue: 1019.53,
        grossIncome: 9.81,
      },
      {
        month: 3,
        initialValue: 1019.53,
        finalValue: 1029.44,
        grossIncome: 9.91,
      },
    ],
  },
};

export type TaxDiscount = {
  id: number;
  startingMonth: number;
  endingMonth: number;
  percentage: number;
};

export const MOCK_DATA_DISCOUNTS = {
  discounts: [
    {
      id: 1,
      startingMonth: 1,
      endingMonth: 6,
      percentage: 22.5,
    },
    {
      id: 2,
      startingMonth: 7,
      endingMonth: 12,
      percentage: 20,
    },
    {
      id: 3,
      startingMonth: 13,
      endingMonth: 24,
      percentage: 17.5,
    },
    {
      id: 4,
      startingMonth: 25,
      endingMonth: 9999,
      percentage: 15,
    },
  ],
};
