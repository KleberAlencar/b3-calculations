using Moq;
using FluentAssertions;
using FizzWare.NBuilder;
using Calculation.Tests.Mock;
using Calculation.Tests.Mock.Entities;
using Calculation.Application.Queries.Handlers;
using Calculation.Application.Queries.Requests;
namespace Calculation.Tests.Application.Handlers
{
    [TestClass]
    public class SearchTaxDiscountsRequestHandlerTest
    {
        private DataContextTest _context;
        private SearchTaxDiscountsRequestHandler _handler;

        [TestInitialize]
        public void Initialize()
        {
            _context = new DataContextTest();
            _handler = new SearchTaxDiscountsRequestHandler(_context);
        }

        [TestMethod]
        public async Task Handle_Test()
        {
            //Arrange
            var request = new SearchTaxDiscountsRequest();
            var expectedResult = Builder<TaxDiscount>.CreateListOfSize(4).Build();

            //Act
            var result = await _handler.Handle(request, It.IsAny<CancellationToken>());

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}