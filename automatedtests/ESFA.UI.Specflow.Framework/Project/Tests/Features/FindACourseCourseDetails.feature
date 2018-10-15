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
| CourseName        | QualificationLevel                                   | Location | Distance |
| English           | Level 3 - A level/Access to higher education diploma | B13 9da  | 10 Miles |
| BUILDING SERVICES | Level 3 - A level/Access to higher education diploma | B13 9DA  | 3 Miles  |



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
    | CourseName             | Location |
    | Maths                  | b13 8py  |
    | Electrical             | b13 8py  |
    | ENGLISH                | BS1 1JG  |
    | COMPUTING              | NE7 7SF  |
    | COMPUTER STUDIES       | M1 1ae   |
    | IT                     | L4 1SE   |
    | INFORMATION TECHNOLOGY | LS1 1UR  |
    | ICT                    | S1 2HE   |
    | COMPUTER SCIENCE       | BD1 1AJ  |
    | SOFTWARE               | b13 9da  |
    | INFORMATION            | ne7 7sf  |
    | COMPUTING              | SW2 1RW  |


@DFC-3973
Scenario Outline: DFC-3973 View Course Details display Qualification
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
    And I enter location <Location>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And Qualification information <Qualification> is displayed

  Examples:
    | CourseName    | Location | Qualification|
    | Hair & Beauty | b14 7en  |Diploma in Hair and Beauty Skills (VRQ)|



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
    | CourseName    | Location | EntryRequirements |
    | Hair & Beauty | b14 7en  | interview         |
    | Electrical    | b14 7en  | To                |
    | baking        | b14 7en  | £72.00            |



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
    | CourseName                                  | Location | Cost            |
    | Horticulture (City & Guilds) Diploma        | b14 7en  | To Be Confirmed |
    | Diploma in Electrical Installation, Level 1 | b14 7en  | £2,200.00       |



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
    | CourseName | Location |
    | health     | b14 7en  |
	
	

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
    | Gardening  | EC1a 1BB |


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
    | cisco      | M1 1AE   |
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
    | cisco      | M1 1AE   |
    | geology    | b14 7rn  |



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
    | cisco      | M1 1AE   |
    | geology    | b14 7rn  |


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
    | cisco      | M1 1AE   |
    | geology    | b14 7rn  |


@DFC-4194
Scenario Outline: DFC-4914 Venue on Google Maps
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I enter location <Location>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And I click on the Google Maps link
	Then I will be on Google Maps page

  Examples:
    | CourseName       | Location |
    | cisco            | M1 1AE   |
    | geology          | b14 7rn  |
    | History         | gu21 6yl |
    | Gardening        | b14 7en  |
    | COMPUTER SCIENCE | BD1 1AJ  |
    | SOFTWARE         | E8 1DY   |
    | INFORMATION      | YO1 6GA  |
    | COMPUTING        | SW2 1RW  |
    | COMPUTING        | NE7 7SF  |
    | english          | M9 0FN   |
    | IT               | L4 1SE   |

@DFC-3976
Scenario Outline: DFC-3976 Provider and Venue details are displayed
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I select qualification <QualificationLevel>
	And I enter location <Location>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And the Provider name is displayed
	And the <Provider/Venue> Name is displayed
	And the Venue Address is displayed
	And the <Provider/Venue> Website is displayed
	And the <Provider/Venue> Email is displayed
	And the <Provider/Venue> Phone Number is displayed

  Examples:
    | CourseName  | QualificationLevel                                   | Location | Provider/Venue |
    | biology     | Level 3 - A level/Access to higher education diploma | B63 3NA  | Venue          |
    | geography   | Level 3 - A level/Access to higher education diploma | B63 3NA  | Venue          |
    | biology     | Level 3 - A level/Access to higher education diploma | B63 3Nb  | Venue          |
    | geography   | Level 3 - A level/Access to higher education diploma | B63 3Nb  | Venue          |
    | ACCOUNTANCY | Level 3 - A level/Access to higher education diploma | B63 3NA  | Venue          |
    | technology  | Level 3 - A level/Access to higher education diploma | B63 3NA  | Venue          |
    | THEOLOGY    | Level 3 - A level/Access to higher education diploma | B63 3NA  | Venue          |


### additional steps required
@DFC-3976
Scenario Outline: DFC-3976 Provider details are displayed when no Venue exists
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And the Provider name is displayed
	And the Provider address is displayed

  Examples:
    | CourseName                   | Location | Provider/Venue |
    | Cyber & Information Security | gu21 6yl | Provider       |



@DFC-3974
Scenario Outline: DFC-3974 Enrol Now Button
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And the Provider name is displayed
	And I click the Enrol Now Button
	Then I am on the provider website

  Examples:
    | CourseName                 |
    | Computer Studies/Computing |
    | Maths                      |
    | biology                    |
    | english                    |
    | physics                    |

@DFC-3974
Scenario Outline: DFC-3974 More Information Button
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And the Provider name is displayed
	And I click the More Information Button
    Then I am on the provider website

  Examples:
    | CourseName |
    | Education    |


@DFC-3975
Scenario Outline: DFC-3975 View Course description
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And the course description is displayed

  Examples:
    | CourseName      |
    | Maths           |
    | cake decoration |
    | cake baking     |


@DFC-3975
Scenario Outline: DFC-3975 View Course equipment
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And the course equipment is displayed

  Examples:
    | CourseName      |
    | CAKE DECORATION |
    | cake baking     |


	@DFC-3975
Scenario Outline: DFC-3975 View Course assessment method
	Given I navigate to Find a Course home page
	When I enter course <CourseName>
	And I click Search
	Then I should be on Search Results for page
	When I select course title
	Then the View Course details page is displayed
	And the course assessment is displayed

  Examples:
    | CourseName |
    | Network Engineering (Cyber Security) BSc Hons Degree Top up  |