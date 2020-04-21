Feature: NegativeFixedDate
	In order to check exchange rates
	As an user
	I want to get the exchange rates for choosen date

Scenario: non existing day of month returns error message
	Given I prepare request with "2011-02-29" parameter
	When I send request
	Then I receive error message: "day is out of range for month"

Scenario: invalid date format returns error message
	Given I prepare request with "2011-13-32" parameter
	When I send request
	Then I receive error message: "time data '2011-13-32' does not match format '%Y-%m-%d'"
