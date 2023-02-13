using Moq;
using FluentAssertions;
using FizzWare.NBuilder;
using Calculation.Domain;
using Microsoft.EntityFrameworkCore;
using Calculation.Infrastructure;
using Calculation.Application.Queries.Requests;
using Calculation.Application.Queries.Handlers;

namespace Calculation.Tests.Application.Handlers
{
    [TestClass]
    public class GetCalculationRequestHandlerTest
    {
        private GetCalculationRequestHandler _getCalculationRequestHandler;

        [TestInitialize]
        public void Initialize()
        {
            var mockSet = new Mock<DbSet<TaxDiscount>>();

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(x => x.TaxDiscount).Returns(mockSet.Object);

            _getCalculationRequestHandler = new GetCalculationRequestHandler(mockContext.Object);
        }

        [TestMethod]
        public async Task Handle_Test()
        {
            //Arrange
            var request = Builder<GetCalculationRequest>.CreateNew().Build();
            var expectedResult = Builder<CdbCalculation>.CreateNew().Build();

            //Act
            var result = await _getCalculationRequestHandler.Handle(request, It.IsAny<CancellationToken>());

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}