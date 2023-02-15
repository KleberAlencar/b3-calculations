using System.Collections.Immutable;
using Moq;
using FluentAssertions;
using FizzWare.NBuilder;
using Calculation.Tests.Mock;
using Calculation.Tests.Mock.Entities;
using Calculation.Application.Queries.Requests;
using Calculation.Application.Queries.Handlers;

namespace Calculation.Tests.Application.Handlers
{
    [TestClass]
    public class GetTaxDiscountRequestHandlerTest
    {
        private DataContextTest _context;
        private GetTaxDiscountRequestHandler _handler;

        [TestInitialize]
        public void Initialize()
        {
            _context = new DataContextTest();
            _handler = new GetTaxDiscountRequestHandler(_context);
        }
        
                [TestMethod]
        public async Task Handle_Test()
        {
            //Arrange
            var request = Builder<GetTaxDiscountRequest>
                .CreateNew()
                .With(x => x.Month = 1)
                .Build();                
            var expectedResult = Builder<TaxDiscount>
                .CreateNew()
                .With(x => x.Id = 1)
                .With(x => x.StartingMonth = 1)
                .With(x => x.EndingMonth = 6)
                .With(x => x.Percentage = 22.5)
                .Build();
 
            //Act
            var result = await _handler.Handle(request, It.IsAny<CancellationToken>());

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}