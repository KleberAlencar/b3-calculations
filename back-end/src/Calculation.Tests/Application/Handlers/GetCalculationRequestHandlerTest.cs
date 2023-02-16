using Moq;
using FluentAssertions;
using Calculation.Domain;
using Calculation.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Calculation.Application.Queries.Requests;
using Calculation.Application.Queries.Handlers;

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
            request.MonthsQuantity = 3;
            var expectedResult = new CdbCalculation(1000, 10, 8, 2);

            var mockSet = new Mock<DbSet<TaxDiscount>>();
            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(m => m.TaxDiscount).Returns(mockSet.Object);

            var _handler = new GetCalculationRequestHandler(mockContext.Object);

            //Act
            var result = await _handler.Handle(request, It.IsAny<CancellationToken>());

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}