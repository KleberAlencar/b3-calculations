using Moq;
using FluentAssertions;
using FizzWare.NBuilder;
using Calculation.Domain;
using Calculation.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Calculation.Application.Queries.Requests;
using Calculation.Application.Queries.Handlers;
using static Calculation.Tests.Helpers.ContextHelper;

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
            var expectedResult = new TaxDiscount(1, 6, 22.5);

            var discounts = new List<TaxDiscount>();
            discounts.Add(expectedResult);
            var queryableDiscount = discounts.AsQueryable();
            CreateContext(queryableDiscount);

            var _handler = new GetTaxDiscountRequestHandler(_context.Object);

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