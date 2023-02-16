using Moq;
using FluentAssertions;
using FizzWare.NBuilder;
using Calculation.Domain;
using Calculation.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Calculation.Application.Queries.Requests;
using Calculation.Application.Queries.Handlers;

namespace Calculation.Tests.Application.Handlers
{
    [TestClass]
    public class GetTaxDiscountRequestHandlerTest
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
            var request = Builder<GetTaxDiscountRequest>
                .CreateNew()
                .With(x => x.Month = 1)
                .Build();                
            var expectedResult = Builder<TaxDiscount>
                .CreateNew()
                .Build();

            var mockSet = new Mock<DbSet<TaxDiscount>>();
            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(m => m.TaxDiscount).Returns(mockSet.Object);
 
            var _handler = new GetTaxDiscountRequestHandler(mockContext.Object);

            //Act
            var result = await _handler.Handle(request, It.IsAny<CancellationToken>());

            //Assert
            result.Value.Should().BeEquivalentTo(expectedResult);
        }
    }
}