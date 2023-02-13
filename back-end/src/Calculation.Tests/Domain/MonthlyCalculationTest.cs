using FluentAssertions;
using Calculation.Domain;

namespace Calculation.Tests.Domain
{
    [TestClass]
    public class MonthlyCalculationTest
    {
        [TestMethod]
        public void Constructor_ShouldCreateInstance()
        {
            //Arrange
            var month = 1;
            var initialValue = 1000.00;
            var finalValue = 1008.00;

            //Act
            var monthlyCalculation = new MonthlyCalculation(month, initialValue, finalValue);

            //Assert
            monthlyCalculation.Month.Should().Be(month);
            monthlyCalculation.InitialValue.Should().Be(initialValue);
            monthlyCalculation.FinalValue.Should().Be(finalValue);
        }
    }
}