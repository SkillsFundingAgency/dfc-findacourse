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
| English           | Level 3 - A level/Access to higher education diploma | B13 9da | 10 Miles |
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
    | CourseName             | Location |
    | Maths                  | b13 8py  |
    | Electrical             | b13 8py  |
    | ENGLISH                | BS1 1JG  |
    | COMPUTING              | NE7 7SF  |
    | COMPUTER STUDIES       | M9 0FN   |
    | IT                     | L4 1SE   |
    | INFORMATION TECHNOLOGY | LS1 1UR  |
    | ICT                    | S1 2HE   |
    | COMPUTER SCIENCE       | BD1 1AJ  |
    | SOFTWARE ENGINEERING   | E8 1DY   |
    | INFORMATION SYSTEMS    | YO1 6GA  |
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
    | CourseName    | Location | EntryRequirements                    |
    | Hair & Beauty | b14 7en  | Successful interview                 |
    | Electrical    | b14 7en  | enter                                |
    | Gardening     | b14 7en  | There are no prerequisites for entry |



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
    | Electrical | b14 7en  | To Be Confirmed |



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
    | health |b14 7en   |
	
	

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
    | Gardening  | EC1a 1BB   |


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
    | baker      | M1 1AE   |
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
    | baker      | M1 1AE  |
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
    | baker      | M1 1AE  |
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
    | baker      | M1 1AE  |
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
    | CourseName                                       | Location |
    | baker                                            | M1 1AE   |
    | geology                                          | b14 7rn  |
    | BTEC Level 4 Certificate in Education & Training | gu21 6yl |
    | Gardening                                        | b14 7en  |
    | COMPUTER SCIENCE                                 | BD1 1AJ  |
    | SOFTWARE ENGINEERING                             | E8 1DY   |
    | INFORMATION SYSTEMS                              | YO1 6GA  |
    | COMPUTING                                        | SW2 1RW  |
    | COMPUTING                                        | NE7 7SF  |
    | COMPUTER STUDIES                                 | M9 0FN   |
    | IT                                               | L4 1SE   |

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
	And the <Provider/Venue> Address is displayed
	And the <Provider/Venue> Website is displayed
	And the <Provider/Venue> Email is displayed
	And the <Provider/Venue> Phone Number is displayed

  Examples:
    | CourseName | QualificationLevel                                   | Location | Provider/Venue |
    | Chemistry  | Level 3 - A level/Access to higher education diploma | B63 3NA  | Venue          |
    | Physics    | Level 3 - A level/Access to higher education diploma | B63 3NA  | Venue          |
    | maths      | Level 3 - A level/Access to higher education diploma | B63 3NA  | Venue          |
    | statistics | Level 3 - A level/Access to higher education diploma | B63 3NA  | Venue          |
    | english    | Level 3 - A level/Access to higher education diploma | B63 3NA  | Venue          |
    | history    | Level 3 - A level/Access to higher education diploma | B63 3NA  | Venue          |
    | geography  | Level 3 - A level/Access to higher education diploma | B63 3NA  | Venue          |


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

  Examples:
    | CourseName                                       | Location | Provider/Venue |
    | BTEC Level 4 Certificate in Education & Training | gu21 6yl | Provider       |


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
    | CourseName |
    | Maths      |
    | biology    |
    | english    |
    | physics    |

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
    | CAKE DECORATION    |