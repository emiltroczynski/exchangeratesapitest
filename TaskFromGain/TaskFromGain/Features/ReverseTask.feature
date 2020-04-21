Feature: ReverseTask
	Given an input string, reverse the string word by word.
    A word is defined as a sequence of non-space characters.
    The input string does not contain leading or trailing spaces and
    the words are always separated by a single space.
    For example,
        Utils.Reverse("the sky is blue") // will return "blue is sky the"
        public static class Text
        {
            public static string Reverse(string text)
            {
            }
        }

Scenario: reverse sentence
	Given I have entered "the sky is blue" into the reverse
	When I execute Reverse
	Then the result should be "blue is sky the"

Scenario: reverse one word
	Given I have entered "the" into the reverse
	When I execute Reverse
	Then the result should be "the"

Scenario: reverse two words
	Given I have entered "the sky" into the reverse
	When I execute Reverse
	Then the result should be "sky the"