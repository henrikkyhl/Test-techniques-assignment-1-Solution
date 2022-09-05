Feature: CalculatePriceExamples
    In order to be able to create an invoice
    As an office clerk at the bus company
    I want to be able to calculate the total price for having rented a bus

Scenario Outline: Calculate price
    Given I have entered a distance of <distance> km.
    And I have also selected a <bustype> bus
    When I press Calculate
    Then the result should be <price>

    Examples:
    | distance | bustype    | price  |
    | 0        | 'Standard' | 2500   |
    | 99       | 'Luxory'   | 4735   |
    | 100      | 'Mini'     | 2598.8 |
    | 500      | 'Standard' | 6698   |
    | 501      | 'Standard' | 6704   |



    Scenario: Calculate price with negative distance
        When I calculate with negative distance
        Then An error should occur
