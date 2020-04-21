Feature: FixedDate
	In order to check exchange rates
	As an user
	I want to get the exchange rates for choosen date

Scenario: valid fixed date returns valid message
	Given I prepare request with "2010-01-12" parameter
	When I send request
	Then I receive response with "EUR" currency and 33 exchange rates and with "2010-01-12" date

Scenario: fixed date in the future returns latest
	Given I prepare request with "2025-01-02" parameter
	When I send request
	Then I receive response with "EUR" currency and 32 exchange rates

Scenario: fixed date for Christmas returns last business day
	Given I prepare request with "2019-12-26" parameter
	When I send request
	Then I receive response with "EUR" currency and 32 exchange rates and with "2019-12-24" date

Scenario: valid with fixed date and symbol
	Given I prepare request with "2011-01-12?symbol=USD" parameter
	When I send request
	Then I receive response with "EUR" currency and 33 exchange rates and with "2011-01-12" date

Scenario: valid with fixed date and base currency
	Given I prepare request with "2009-01-12?base=USD" parameter
	When I send request
	Then I receive response with "USD" currency and 34 exchange rates and with "2009-01-12" date
