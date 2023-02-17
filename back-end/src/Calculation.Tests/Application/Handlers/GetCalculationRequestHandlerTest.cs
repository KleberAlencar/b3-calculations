using Moq;
using FluentAssertions;
using Calculation.Domain;
using Calculation.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Calculation.Application.Queries.Requests;
using Calculation.Application.Queries.Handlers;
using static Calculation.Tests.Helpers.ContextHelper;

namespace Calculation.Tests.Application.Handlers
{
    [TestClass]
    public class GetCalculationRequestHandlerTest
    {
        private Mock<IDataContext> _context;

        [TestInitialize]
        public void Initialize()
        {
            _context = new Mock<IDataContext>();
        }

        [TestMethod]
        public async Task Handle_Test()
        {
            //Arrange
            var request = new GetCalculationRequest();
            request.Investiment = 1000;
            request.MonthsQuantity = 2;

            var taxDiscount = new TaxDiscount(1, 6, 22.5);
            
            var expectedResult = new CdbCalculation(1000, 0, 0, 0);
            expectedResult.AddMonthyCalculation(new MonthlyCalculation(1, 1000.00, 1009.72));
            expectedResult.AddMonthyCalculation(new MonthlyCalculation(2, 1009.72, 1019.53));
            expectedResult.UpdateTaxDiscountValue(4.39);
            expectedResult.UpdateGrossIncome(19.53);
            expectedResult.UpdateNetIncome(15.14);

            var discounts = new List<TaxDiscount>();
            discounts.Add(taxDiscount);
            var queryableDiscount = discounts.AsQueryable();
            CreateContext(queryableDiscount);

            var _handler = new GetCalculationRequestHandler(_context.Object);

            //Act
            var result = await _handler.Handle(request, It.IsAny<CancellationToken>());

            //Assert
            result.Value.Should().BeEquivalentTo(expectedResult);
        }

        private void CreateContext(IQueryable<TaxDiscount> expectedResult)
        {
            var mockSet = new Mock<DbSet<TaxDiscount>>();
            mockSet.As<IAsyncEnumerable<TaxDiscount>>()
                .Setup(m => m.GetAsyncEnumerator(CancellationToken.None))
                .Returns(new TestAsyncEnumerator<TaxDiscount>(expectedResult.GetEnumerator()));

            mockSet.As<IQueryable<TaxDiscount>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<TaxDiscount>(expectedResult.Provider));

            mockSet.As<IQueryable<TaxDiscount>>().Setup(m => m.Expression).Returns(expectedResult.Expression);
            mockSet.As<IQueryable<TaxDiscount>>().Setup(m => m.ElementType).Returns(expectedResult.ElementType);
            mockSet.As<IQueryable<TaxDiscount>>().Setup(m => m.GetEnumerator()).Returns(expectedResult.GetEnumerator());

            _context.Setup(s => s.TaxDiscount).Returns(mockSet.Object);
        }
    }
}