Feature: History
	In order to check historical exchange rates
	As an user
	I want to get the historical exchange rates

Scenario: historical exchange rate for 1 day returns 1 day
	Given I prepare request with "history?start_at=2018-01-03&end_at=2018-01-03" parameter
	When I send request
	Then I receive response with "EUR" start: "2018-01-03" end: "2018-01-03" and 1 days

Scenario: historical exchange rate for 2 days returns 2 days
	Given I prepare request with "history?start_at=2018-01-03&end_at=2018-01-04" parameter
	When I send request
	Then I receive response with "EUR" start: "2018-01-03" end: "2018-01-04" and 2 days

Scenario: historical exchange rate for 2 days and base USD returns 2 days
	Given I prepare request with "history?start_at=2018-01-03&end_at=2018-01-04&base=USD" parameter
	When I send request
	Then I receive response with "USD" start: "2018-01-03" end: "2018-01-04" and 2 days

Scenario: historical exchange rate for 2 days and symbols ILS,JPY returns only 2 currencies
	Given I prepare request with "history?start_at=2018-01-03&end_at=2018-01-04&symbols=ILS,JPY" parameter
	When I send request
	Then I receive response with "EUR" start: "2018-01-03" end: "2018-01-04" and 2 currencies

