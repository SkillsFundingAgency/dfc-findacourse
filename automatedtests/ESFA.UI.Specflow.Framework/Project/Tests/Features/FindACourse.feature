Feature: Find A Course
	As a user
	I am able to access and use the Find a Course Page
	
@Regression
	Scenario Outline: User search on Find a Course page
		Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I select qualification <QualificationLevel>
		And I enter location <Location> 
		And I select distance <Distance>
		And I click Search
#		Then I should be on Search Results for page

  Examples:
    | CourseName  | QualificationLevel                                   | Location   | Distance |
    | Chemistry   | Entry level - Skills for Life                        | Birmingham | 1 Mile   |
    | Bricklaying | Level 1 - First certificate                          | London     | 3 Miles  |
    | Maths       | Level 2 - GCSE/O level                               | London     | 5 Miles  |
    | English     | Level 3 - A level/Access to higher education diploma | Birmingham | 10 Miles |
    | Plumbing    | Level 4 - Certificate of higher education/HNC        | London     | 15 Miles |
    | Electronic  | Level 5 - Foundation degree/HND                      | London     | 20 Miles |
    | Medicine    | Level 6 - Degree/Graduate diploma                    | Birmingham | National |
    | Biology     | Level 7 - Masters Degree/Postgraduate diploma        | London     | 3 Miles  |
    | Physics     | Level 8 - Doctorate/PhD                              | London     | 5 Miles  |


@Regression
	Scenario Outline: User search on Find a Course page using Autopopulate
		Given I navigate to Find a Course home page
		When one letter at a time <CourseName>
		Then the Course suggestions <AutopopulateList> displayed
		And I Can select one of the List options <CourseName>
		When I click Search
#		Then I should be on Search Results for page

  Examples:
    | CourseName | AutopopulateList                                                                                                      |
    | team       | TEAM,TEAM BUILDING,TEAM WORK,TEAM WORKING,TEAMWORK,TEAMWORKING                                                        |
    | builder    | BUILDER,BUILDING,BUILDING MAINTENANCE,BUILDING SERVICES,BUILDING SERVICES ENGINEERING,BUILDING SURVEYING,CONSTRUCTION |
	

@Regression
	Scenario: User contacts adviser from Find a Course page
		Given I navigate to Find a Course home page
		When I click Contact an adviser link
		Then I will be on Contact us page


@Regression
	Scenario: User wants more information on Qualifications
		Given I navigate to Find a Course home page
		When I click What qualification levels mean link
		Then I will be on What qualification levels mean page


@BrowserStack
Scenario Outline: BrowserStack Test Find a Course
  Given I am on Find a Course for <profile> and <environment>
		When I enter course <CourseName>
		And  I select qualification <QualificationLevel>
		And I enter location <Location> 
		And I select distance <Distance>
		And I click Search
	#	Then I should be on Search Results for page

  Examples:
        | profile  | environment   | CourseName  | QualificationLevel            | Location   | Distance |
        | single   | chrome        | Chemistry   | Entry level - Skills for Life | Birmingham | 1 Mile   |
        | parallel | safari        | Bricklaying | Level 1 - First certificate   | London     | 3 Miles  |
        | parallel | chrome        | Bricklaying | Level 1 - First certificate   | London     | 3 Miles  |
        | parallel | firefox       | Bricklaying | Level 1 - First certificate   | London     | 3 Miles  |
        | parallel | ie            | Bricklaying | Level 1 - First certificate   | London     | 3 Miles  |
        | parallel | edge          | Bricklaying | Level 1 - First certificate   | London     | 3 Miles  |
        | parallel | chromeios     | Bricklaying | Level 1 - First certificate   | London     | 3 Miles  |
        | parallel | chromeandroid | Bricklaying | Level 1 - First certificate   | London     | 3 Miles  |
