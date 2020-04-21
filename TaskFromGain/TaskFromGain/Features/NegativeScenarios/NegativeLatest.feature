Feature: NegativeLatest
	In order to check exchange rates
	As an user
	I want to get the latest exchange rates

Scenario: request with invalid latest paramater
	Given I prepare request with "lates" parameter
	When I send request
	Then I receive error message: "time data 'lates' does not match format '%Y-%m-%d'"

Scenario: request with latest and invalid symbols USA, GBB
	Given I prepare request with "latest?symbols=USA,GBB" parameter
	When I send request
	Then I receive error message with "USA,GBB" currency and latest date