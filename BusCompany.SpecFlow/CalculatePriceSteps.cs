using System;
using TechTalk.SpecFlow;
using Xunit;

namespace BusCompany.SpecFlow
{
    [Binding]
    public class CalculatePriceSteps
    {
        private int distance;
        private BusType bustype;
        private decimal price;
        private PriceCalculator calc = new PriceCalculator();

        [Given(@"I have entered a distance of (.*) km\.")]
        public void GivenIHaveEnteredADistanceOfKm_(int distance)
        {
            this.distance = distance;
        }

        [Given(@"I have also selected a '(.*)' bus")]
        public void GivenIHaveAlsoSelectedABus(BusType bustype)
        {
            this.bustype = bustype;
        }

        [When(@"I press Calculate")]
        public void WhenIPressCalculate()
        {
            price = calc.CalculatePrice(distance, bustype);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(decimal expectedPrice)
        {
            Assert.Equal(expectedPrice, price);
        }
    }
}
