using System;
using TechTalk.SpecFlow;
using Xunit;

namespace BusCompany.SpecFlow
{
    [Binding]
    //[Scope(Feature = "CalculatePriceExamples")]
    public class CalculatePriceSteps
    {
        private int distance;
        private BusType bustype;
        private decimal price;
        private Action action;
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
        
        [When(@"I calculate with negative distance")]
        public void WhenICalculateWithNegativeDistance()
        { 
            action = () => calc.CalculatePrice(-1, BusType.Standard);
        }

        [Then(@"An error should occur")]
        public void ThenAnErrorShouldOccur()
        {
            Assert.Throws<ArgumentException>(action);
        }
    }
}
