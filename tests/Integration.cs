using Xunit;
using NPC.models;
using NPC;

namespace tests
{
    public class OrderManagerTests
    {
        private readonly DiscountConfig _discountConfig;

        public OrderManagerTests()
        {
            _discountConfig = new DiscountConfig
            {
                ChildDiscounts = new Dictionary<string, decimal> { { "0-3", 50 }, { "4-11", 20 } },
                DisabilityDiscountPercentage = 90,
                EarlyOrderDiscount = new EarlyOrderDiscount { LimitHour = 20, Percentage = 10 },
                FidelityCardDiscountPercentage = 15,
                GroupDiscounts = new Dictionary<string, decimal> { { "15-20", 20 }, { "21-25", 30 }, { "26", 50 } },
                SeniorCitizenDiscount = new SeniorCitizenDiscount { AgeThreshold = 60, Percentage = 70 },
                WeekendDiscountPercentage = 10,
            };
        }

        [Fact]
        public void ProcessOrder_Appplies0Discount()
        {
            // Arrange
            var orderManager = new OrderManager(_discountConfig);
            var fidelityDiscountOrder = new OrderInfo(fullPrice: 100, hasFidelityCard: false, hasDisability: false, groupSize: 1, orderDateTime: new DateTime(2024, 08, 28, 22, 0, 0), customerAge: 25);
            var expectedResult = 100m;

            // Act
            var actualResult = orderManager.ProcessOrder(fidelityDiscountOrder);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ProcessOrder_ApppliesFidelityCardDiscount()
        {
            // Arrange
            var orderManager = new OrderManager(_discountConfig);
            var fidelityDiscountOrder = new OrderInfo(fullPrice: 100, hasFidelityCard: true, hasDisability: false, groupSize: 1, orderDateTime: new DateTime(2024, 08, 28, 22, 0, 0), customerAge: 25);
            var expectedResult = 85m;

            // Act
            var actualResult = orderManager.ProcessOrder(fidelityDiscountOrder);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ProcessOrder_ApppliesDisabilityDiscount()
        {
            // Arrange
            var orderManager = new OrderManager(_discountConfig);
            var disabilityDiscountOrder = new OrderInfo(fullPrice: 100, hasFidelityCard: false, hasDisability: true, groupSize: 1, orderDateTime: new DateTime(2024, 08, 28, 22, 0, 0), customerAge: 25);
            var expectedResult = 10m;

            // Act
            var actualResult = orderManager.ProcessOrder(disabilityDiscountOrder);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Processorder_ApppliesSmallgGroupDiscount()
        {
            // Arrange
            var orderManager = new OrderManager(_discountConfig);
            var smallGroupOrder = new OrderInfo(fullPrice: 100, hasFidelityCard: false, hasDisability: false, groupSize: 15, orderDateTime: new DateTime(2024, 08, 28, 22, 0, 0), customerAge: 25);
            var expectedResult = 80m;

            // Act
            var actualResult = orderManager.ProcessOrder(smallGroupOrder);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Processorder_ApppliesMediumGroupDiscount()
        {
            // Arrange
            var orderManager = new OrderManager(_discountConfig);
            var mediumGroupOrder = new OrderInfo(fullPrice: 100, hasFidelityCard: false, hasDisability: false, groupSize: 25, orderDateTime: new DateTime(2024, 08, 28, 22, 0, 0), customerAge: 25);
            var expectedResult = 70m;

            // Act
            var actualResult = orderManager.ProcessOrder(mediumGroupOrder);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Processorder_ApppliesBigGroupDiscount()
        {
            // Arrange
            var orderManager = new OrderManager(_discountConfig);
            var bigGroupOrder = new OrderInfo(fullPrice: 100, hasFidelityCard: false, hasDisability: false, groupSize: 26, orderDateTime: new DateTime(2024, 08, 28, 22, 0, 0), customerAge: 25);
            var expectedResult = 50m;

            // Act
            var actualResult = orderManager.ProcessOrder(bigGroupOrder);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ProcessOrder_ApppliesBigChildDiscountIfNoGroupDiscount()
        {
            // Arrange
            var orderManager = new OrderManager(_discountConfig);
            var bigChildOrder = new OrderInfo(fullPrice: 100, hasFidelityCard: false, hasDisability: false, groupSize: 1, orderDateTime: new DateTime(2024, 08, 28, 22, 0, 0), customerAge: 10);
            var expectedResult = 80m;

            // Act
            var actualResult = orderManager.ProcessOrder(bigChildOrder);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ProcessOrder_ApppliesSmallChildDiscountIfNoGroupDiscount()
        {
            // Arrange
            var orderManager = new OrderManager(_discountConfig);
            var smallChildOrder = new OrderInfo(fullPrice: 100, hasFidelityCard: false, hasDisability: false, groupSize: 1, orderDateTime: new DateTime(2024, 08, 28, 22, 0, 0), customerAge: 3);
            var expectedResult = 50m;

            // Act
            var actualResult = orderManager.ProcessOrder(smallChildOrder);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ProcessOrder_ApppliesSeniorCitizenDiscount()
        {
            // Arrange
            var orderManager = new OrderManager(_discountConfig);
            var seniorCitizenOrder = new OrderInfo(fullPrice: 100, hasFidelityCard: false, hasDisability: false, groupSize: 1, orderDateTime: new DateTime(2024, 08, 28, 22, 0, 0), customerAge: 70);
            var expectedResult = 30m;

            // Act
            var actualResult = orderManager.ProcessOrder(seniorCitizenOrder);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ProcessOrder_ApppliesEarlyOrderDiscount()
        {
            // Arrange
            var orderManager = new OrderManager(_discountConfig);
            var earlyOrder = new OrderInfo(fullPrice: 100, hasFidelityCard: false, hasDisability: false, groupSize: 1, orderDateTime: new DateTime(2024, 08, 28, 15, 0, 0), customerAge: 50);
            var expectedResult = 90m;

            // Act
            var actualResult = orderManager.ProcessOrder(earlyOrder);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ProcessOrder_ApppliesWeekEndOrderDiscount()
        {
            // Arrange
            var orderManager = new OrderManager(_discountConfig);
            var weekendOrder = new OrderInfo(fullPrice: 100, hasFidelityCard: false, hasDisability: false, groupSize: 1, orderDateTime: new DateTime(2024, 08, 31, 23, 0, 0), customerAge: 50);
            var expectedResult = 90m;

            // Act
            var actualResult = orderManager.ProcessOrder(weekendOrder);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }

}
