using System.Collections.Generic;
using TCO.SNT.Entities;
using Xunit;

namespace TCO.SNT.Tests
{
    public class UFormTests
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 0M, 2.1M, 0M },
                new object[] { 1.1M, 2.2M, 2.42M }
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void Test_UFormProduct_CalculateTotal(decimal price, decimal quantity, decimal sum)
        {
            // Arrange
            var product = new UFormProduct
            {
                Price = price,
                Quantity = quantity
            };

            // Act
            product.CalculateTotal();

            // Assert
            Assert.Equal(sum, product.Sum);
        }

        [Fact]
        public void Test_UForm_CalculateTotal()
        {
            // Arrange
            var form = new UForm();
            form.Products.Add(new UFormProduct { Price = 0m, Quantity = 1.2m });
            form.Products.Add(new UFormProduct { Price = 2.2m, Quantity = 1.2m });
            
            // Act
            form.CalculateTotal();

            // Assert
            Assert.Equal(2.64m, form.TotalSum);
        }
    }
}
