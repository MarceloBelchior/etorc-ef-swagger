using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using torc;
using torc.database;
using torc.model;

namespace torc.Test
{

    public class EntityFrameworkTest
    {

        private Mock<database.TorcDB> mockDbContext;
        private ProductRepository repository;
        [SetUp]
        public void Setup()
        {
            // Create a mock instance of your DbContext
            mockDbContext = new Mock<TorcDB>();


            //To use Test - comment construtor.

            // Pass the mock DbContext to your repository class
            repository = new ProductRepository(mockDbContext.Object); 
        }



        [Test]
        public void GetProduct()
        {
            // Arrange
            var pd = new List<Product>
        {
           new Product() { Id =1 , Name = "test 1", Price = 12.11M}

        }.AsQueryable();

            // Set up the mock DbContext's DbSet to return the test data
            mockDbContext.Setup(db => db.Products).Returns(MockDbSet(pd));

            // Act
            Expression<Func<Product, bool>> expression = m => m.Id == 1;
            var result = repository.Select(expression);

            // Assert
            Assert.AreEqual(pd.Count(), result.Count());
        }

        private static DbSet<T> MockDbSet<T>(IQueryable<T> data) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return mockSet.Object;
        }
    }
}
