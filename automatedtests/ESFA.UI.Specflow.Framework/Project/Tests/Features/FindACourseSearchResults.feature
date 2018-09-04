Feature: Find A  Course Search Results Page
	As a user
	I am able to view and use the Search Results
	
Background: 
		Given I navigate to Find a Course home page
		When I enter course Biology
		And I select qualification Entry level - Skills for Life 
		And I enter location Birmingham
		And I select distance 1 Mile
		And I click Search
#		Then I should be on Search Results for page


@DFC-3900
 Scenario: DFC3900 View Search Results By Course Name Valid Results
		Given I am on the Search Results page
		Then Valid Results are returned


@DFC-3900
 Scenario: DFC3900 View Search Results By Course Name Null Results
		Given I am on the Search Results page
		Then no results found message is displayed


@DFC-3900
 Scenario: DFC3900 View Search Results By Course Name
		Given I am on the Search Results page
		Then to be written