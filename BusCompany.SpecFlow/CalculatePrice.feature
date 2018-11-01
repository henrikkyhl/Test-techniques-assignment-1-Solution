Feature: CalculatePrice
	In order to be able to create an invoice
	As an office clerk at the bus company
	I want to be able to calculate the total price for having rented a bus

Scenario: Calculate price
	Given I have entered a distance of 100 km.
	And I have also selected a 'Mini' bus
	When I press Calculate
	Then the result should be 2598.8
