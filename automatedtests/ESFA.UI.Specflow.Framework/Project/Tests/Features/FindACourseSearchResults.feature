Feature: Find A  Course Search Results Page
	As a user
	I am able to view and use the Search Results
	
		Given I navigate to Find a Course home page
		When I enter course Biology
		And I select qualification Entry level - Skills for Life 
		And I enter location Birmingham
		And I select distance 1 Mile
		And I click Search
#		Then I should be on Search Results for page


@DFC-3900
 Scenario: DFC3900 View Search Results By Course Name Valid Results
 		Given I navigate to Find a Course home page
		When I enter course Biology
		And I click Search
		Then I should be on Search Results for page
		And Valid Results are returned


@DFC-3900
 Scenario Outline: DFC3900 View Search Results By Course Name Null Results
		Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page
		And no results found message is displayed

  Examples:
    | CourseName  | 
    | bbbbbbbbb   | 


@DFC-3900
 Scenario Outline: DFC3900 View Search Results By Course Name
		Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page
		And the course title <CourseTitle> is displayed
		And the course level <CourseLevel> is displayed

  Examples:
    | CourseName | CourseTitle | CourseLevel            |
    | Biology    | Biology     | Unknown/not applicable |
    | Chemistry  | Chemi       | Level 6                |