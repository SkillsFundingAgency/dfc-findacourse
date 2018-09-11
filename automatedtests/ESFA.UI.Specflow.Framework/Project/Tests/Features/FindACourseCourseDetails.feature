Feature: Find A Course Course Details
	As a user
	I am able to access and use the Course Details page


@DFC-4194
Scenario Outline: DFC-4194 View Course Details
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I select qualification <QualificationLevel>
	And I enter location <Location> 
	And I select distance <Distance>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And course title information is displayed

Examples:
| CourseName        | QualificationLevel                                   | Location   | Distance | 
| Maths             | Level 2 - GCSE/O level                               | London     | 5 Miles  |
| English           | Level 3 - A level/Access to higher education diploma | Birmingham | 10 Miles |
| BUILDING SERVICES | Level 3 - A level/Access to higher education diploma | B13 9DA    | 3 Miles  | 
| Bricklaying       | Level 1 - First certificate                          | London     | 3 Miles  | 
| Maths             | Level 2 - GCSE/O level                               | London     | 5 Miles  |
| English           | Level 3 - A level/Access to higher education diploma | Birmingham | 10 Miles |
| Electronic        | Level 5 - Foundation degree/HND                      | London     | 20 Miles |



@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Course Title
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And course title information is displayed

  Examples:
    | CourseName |
    | Maths      |
    | Electrical |
    | horse      |



@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Qualification
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Qualification information <Qualification> is displayed

  Examples:
    | CourseName    | Qualification|
    | Hair & Beauty | Hair and Beauty - Introduction to the Hairdressing and Beauty Sector (Hair & Beauty Route) |



@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Entry Requirements
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Entry Requirements are displayed

  Examples:
    | CourseName |
    | Maths      |
    | Electrical |
    | horse      |


@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Cost
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Cost Details are displayed

  Examples:
    | CourseName |
    | Maths      |
    | Electrical |
    | horse      |


@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Loans
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Advanced learner loans details are displayed

  Examples:
    | CourseName |
    | Maths      |
    | Electrical |
    | horse      |
	
	
@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Start Date
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Course Start Date details are displayed

  Examples:
    | CourseName |
    | Maths      |
    | Electrical |
    | horse      |


@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Duration
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Course Duration details are displayed

  Examples:
    | CourseName |
    | Maths      |
    | Electrical |


@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Study Mode
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Study Mode details are displayed

  Examples:
    | CourseName |
    | Maths      |
    | Electrical |


@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Attendance Pattern
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Attendance Pattern details are displayed

  Examples:
    | CourseName |
    | Maths      |
    | Electrical |