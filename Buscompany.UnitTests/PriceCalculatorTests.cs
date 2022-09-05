using Xunit;

namespace BusCompany.UnitTests
{
    public class PriceCalculatorTests
    {
        PriceCalculator calculator;

        public PriceCalculatorTests(){
            calculator = new PriceCalculator();
        }

        [Theory]
        [InlineData(0, BusType.Standard, 2500)]
        [InlineData(99, BusType.Luxory, 4735)]
        [InlineData(100, BusType.Mini, 2598.8)]
        [InlineData(500, BusType.Standard, 6698)]
        [InlineData(501, BusType.Standard, 6704)]
        public void CalculatePrice_ValidInlineData_PriceIsCorrect(int distance, BusType busType, decimal expectedPrice)
        {
            //Arrange
            PriceCalculator calculator = new PriceCalculator();
            //Act
            decimal price = calculator.CalculatePrice(distance, busType);
            //Assert
            Assert.Equal(expectedPrice, price);
        }

        [Fact]
        public void CalculatePrice_NegativeDistance_ThrowsException()
        {
            Assert.Throws<System.ArgumentException>(() => calculator.CalculatePrice(-1, BusType.Standard));
        }

    }
}
