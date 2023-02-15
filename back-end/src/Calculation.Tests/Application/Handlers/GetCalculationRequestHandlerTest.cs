using Moq;
using FluentAssertions;
using Calculation.Domain;
using Calculation.Tests.Mock;
using Calculation.Application.Queries.Requests;
using Calculation.Application.Queries.Handlers;

namespace Calculation.Tests.Application.Handlers
{
    [TestClass]
    public class GetCalculationRequestHandlerTest
    {
        private DataContextTest _context;
        private GetCalculationRequestHandler _handler;

        [TestInitialize]
        public void Initialize()
        {
            _context = new DataContextTest();
            _handler = new GetCalculationRequestHandler(_context);
        }

        [TestMethod]
        public async Task Handle_Test()
        {
            //Arrange
            var request = new GetCalculationRequest();
            request.Investiment = 1000;
            request.MonthsQuantity = 3;
            var expectedResult = new CdbCalculation(1000, 10, 8, 2);

            //Act
            var result = await _handler.Handle(request, It.IsAny<CancellationToken>());

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}