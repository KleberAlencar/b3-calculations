using FluentAssertions;
using Calculation.Domain;

namespace Calculation.Tests.Domain
{
    [TestClass]
    public class CdbCalculationTest
    {
        [TestMethod]
        public void Constructor_ShouldCreateInstance()
        {
            //Arrange
            var investiment = 1000.00;
            var grossIncome = 10.00; 
            var netIncome = 8.00;
            var taxDiscountValue = 2.00;

            //Act
            var cdbCalculation = new CdbCalculation(investiment, grossIncome, netIncome, taxDiscountValue);

            //Assert
            cdbCalculation.Investiment.Should().Be(investiment);
            cdbCalculation.GrossIncome.Should().Be(grossIncome);
            cdbCalculation.NetIncome.Should().Be(netIncome);
            cdbCalculation.TaxDiscountValue.Should().Be(taxDiscountValue);
        }
    }
}