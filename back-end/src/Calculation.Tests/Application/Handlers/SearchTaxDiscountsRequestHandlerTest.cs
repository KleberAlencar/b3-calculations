using Moq;
using FluentAssertions;
using FizzWare.NBuilder;
using Calculation.Domain;
using Calculation.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Calculation.Application.Queries.Handlers;
using Calculation.Application.Queries.Requests;
using static Calculation.Tests.Helpers.ContextHelper;

namespace Calculation.Tests.Application.Handlers
{
    [TestClass]
    public class SearchTaxDiscountsRequestHandlerTest
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
            var request = Builder<SearchTaxDiscountsRequest>.CreateNew().Build();
            var expectedResult = Builder<TaxDiscount>.CreateListOfSize(4).Build().AsQueryable();
            
            CreateContext(expectedResult);

            var _handler = new SearchTaxDiscountsRequestHandler(_context.Object);

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