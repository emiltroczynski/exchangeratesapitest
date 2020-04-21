Feature: NegativeHistory
	In order to check historical exchange rates
	As an user
	I want to get the historical exchange rates

Scenario: historical exchange rate with invalid symbols returns error message
	Given I prepare request with "history?start_at=2018-01-03&end_at=2018-01-04&symbols=USA,JPY" parameter
	When I send request
	Then I receive error message: "Symbols 'USA,JPY' are invalid."

Scenario: historical exchange rate with invalid start_at returns error message
	Given I prepare request with "history?start_at=2018-13-03&end_at=2018-01-04" parameter
	When I send request
	Then I receive error message: "start_at parameter format"

Scenario: historical exchange rate with invalid end_at returns error message
	Given I prepare request with "history?start_at=2018-01-03&end_at=2018-13-04" parameter
	When I send request
	Then I receive error message: "end_at parameter format"