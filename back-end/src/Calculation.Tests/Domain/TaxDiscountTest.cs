using FluentAssertions;
using Calculation.Domain;

namespace Calculation.Tests.Domain
{
    [TestClass]
    public class TaxDiscountTest
    {
        [TestMethod]
        public void Constructor_ShouldCreateInstance()
        {
            //Arrange
            var startingMonth = 1;
            var endingMonth = 6;
            var percentage = 22.5;

            //Act
            var taxDiscount = new TaxDiscount(startingMonth, endingMonth, percentage);

            //Assert
            taxDiscount.StartingMonth.Should().Be(startingMonth);
            taxDiscount.EndingMonth.Should().Be(endingMonth);
            taxDiscount.Percentage.Should().Be(percentage);
        }
    }
}