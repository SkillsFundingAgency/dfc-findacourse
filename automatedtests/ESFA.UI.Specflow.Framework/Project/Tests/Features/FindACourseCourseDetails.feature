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
| English           | Level 3 - A level/Access to higher education diploma | Birmingham | 10 Miles |
| BUILDING SERVICES | Level 3 - A level/Access to higher education diploma | B13 9DA    | 3 Miles  |  



@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Course Title
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
    And I enter location <Location>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And course title information is displayed

  Examples:
    | CourseName | Location |
    | Maths      | b13 8py  |
    | Electrical | b13 8py  |


# BUG
#@DFC-3973
#Scenario Outline: DFC-3973 View Course Details display Qualification
#	Given I navigate to Find a Course home page
#	When I enter course <CourseName>
#    And I enter location <Location>
#	And I click Search
#	Then I should be on Search Results for page
#	When I select course title
#	Then the View Course details page is displayed
#	And Qualification information <Qualification> is displayed
#
#  Examples:
#    | CourseName    | Location | Qualification|
#    | Hair & Beauty | b14 7en  |Hair and Beauty - Introduction to the Hairdressing and Beauty Sector (Hair & Beauty Route) |



@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Entry Requirements
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I enter location <Location>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Entry Requirements <EntryRequirements> are displayed

  Examples:
    | CourseName    | Location | EntryRequirements                                      |
    | Hair & Beauty | b14 7en  | There are no formal entry requirements                 |
    | Electrical    | b14 7en  | City & Guilds 2365 Level 2.City & Guilds 2330 Level 2. |
    | Gardening     | b14 7en  | There are no prerequisites for entry                   |



@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Cost
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
    And I enter location <Location>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Cost Details <Cost> are displayed

  Examples:
    | CourseName | Location | Cost                                  |
    | Gardening  | b14 7en  | Tbc                                   |
    | Electrical | b14 7en  | Concessions May Apply. Please Enquire |



@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Loans
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
    And I enter location <Location>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And I click the advanced learner link
	Then I will be on the advanced learner loan page

  Examples:
    | CourseName |Location|
    | Electrical |b14 7en   |
	
	

@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Start Date
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I enter location <Location>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Course Start Date details are displayed

  Examples:
    | CourseName | Location |
    | Gardening  | London   |




@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Duration
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I enter location <Location>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Course Duration details are displayed

  Examples:
    | CourseName | Location |
    | baker      | cv1 2nl   |
    | geology    | b14 7rn  |



@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Study Mode
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I enter location <Location>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Study Mode details are displayed

  Examples:
    | CourseName | Location |
    | baker      | cv1 2nl  |



@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Attendance Pattern
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I enter location <Location>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Attendance Pattern details are displayed

  Examples:
    | CourseName | Location |
    | baker      | cv1 2nl  |


	@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Attendance Mode
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I enter location <Location>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Attendance Pattern Mode are displayed

  Examples:
    | CourseName | Location |
    | baker      | cv1 2nl  |