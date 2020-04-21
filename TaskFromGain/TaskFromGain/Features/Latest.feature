Feature: Latest
	In order to check exchange rates
	As an user
	I want to get the latest exchange rates

Scenario: request with latest
	Given I prepare request with "latest" parameter
	When I send request
	Then I receive response with "EUR" currency and 32 exchange rates

Scenario: request with latest and base=USD
	Given I prepare request with "latest?base=USD" parameter
	When I send request
	Then I receive response with "USD" currency and 33 exchange rates

Scenario: request with latest and symbol USD, GBP
	Given I prepare request with "latest?symbols=USD,GBP" parameter
	When I send request
	Then I receive response with "EUR" currency and 2 exchange rates