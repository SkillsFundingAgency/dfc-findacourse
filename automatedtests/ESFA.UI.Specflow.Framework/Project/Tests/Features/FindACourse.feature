Feature: Find A Course Search Page
	As a user
	I am able to access and use the Find a Course Page

@DFC-3885
	Scenario Outline: DFC-3885 Select Location and Distance
		Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I enter location <Location> 
		And I select distance <Distance>

  Examples:
    | CourseName  | Location | Distance |
    | Chemistry   | b13 9da  | 1 Mile   |
    | Bricklaying | B13 9DA  | 3 Miles  |
    | Maths       | b13 9da  | 5 Miles  |
    | English     | b13 9da  | 10 Miles |
    | Plumbing    | b13 9da  | 15 Miles |
    | Electronic  | b13 9da  | 20 Miles |
    | Medicine    | b13 9da  | National |  


@DFC-4090
	Scenario Outline: DFC-4090 Search for Courses By Location & Distance
		Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I enter location <Location> 
		And I select distance <Distance>
		And I click Search
		Then I should be on Search Results for page
		And Search <Location> displayed in location field

  Examples:
    | CourseName  | Location | Distance |
    | Chemistry   | b13 9da  | 1 Mile   |
    | Bricklaying | B13 9DA  | 3 Miles  |
    | Maths       | B14 7EN  | 5 Miles  |
    | English     | b14 7rn  | 10 Miles |
    | Plumbing    | b14 7rz  | 15 Miles |
    | Electronic  | b13 8py  | 20 Miles |
    | Medicine    | b13 9ah  | National |


@DFC-4090
	Scenario Outline: DFC-4090 Search for Courses By Location & Distance Invalid Location
		Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I enter location <Location> 
		And I select distance <Distance>
		And I click Search
		Then postcode validation failure message is displayed

  Examples:
    | CourseName  | Location           | Distance |
    | Chemistry   | honalulu           | 1 Mile   |
    | Bricklaying | x99 9xx            | 3 Miles  |
    | Maths       | davy st, edinburgh | 5 Miles  |
    | English     | xxxxxxxxx          | 10 Miles |
    | Plumbing    | wherever           | 15 Miles |
    | Electronic  | anywhere           | 20 Miles |
    | Medicine    | nowhere            | National | 	


@DFC-4090
Scenario Outline: DFC-4090 Search for Courses By Location & Distance Null Results
		Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I enter location <Location> 
		And I select distance <Distance>
		And I click Search
		Then I should be on Search Results for page
		And no results found message is displayed

  Examples:
    | CourseName | Location | Distance |
    | ARCHAEOLOGIST   | PO30 1DN  | 1 Mile   |
 

@DFC-3884
	Scenario Outline: DFC-3884 Select Qualification Level
		Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I select qualification <QualificationLevel>

  Examples:
    | CourseName  | QualificationLevel                                   |
    | Chemistry   | Entry level - Skills for Life                        | 
    | Bricklaying | Level 1 - First certificate                          | 
    | Maths       | Level 2 - GCSE/O level                               | 
    | English     | Level 3 - A level/Access to higher education diploma |
    | Plumbing    | Level 4 - Certificate of higher education/HNC        |
    | Electronic  | Level 5 - Foundation degree/HND                      |
    | Medicine    | Level 6 - Degree/Graduate diploma                    |
    | Biology     | Level 7 - Masters Degree/Postgraduate diploma        |
    | Physics     | Level 8 - Doctorate/PhD                              | 


@DFC-3884
	Scenario Outline: DFC-3884 Select Qualification Level Default Value
		Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And Qualification Level field displays default Select level

  Examples:
    | CourseName  | QualificationLevel                                   |
    | Chemistry   | Entry level - Skills for Life                        | 


@DFC-4091
	Scenario Outline: DFC-4091 Search for Courses By Qualification Level
		Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I select qualification <QualificationLevel>
		And I click Search
		Then I should be on Search Results for page

  Examples:
    | CourseName  | QualificationLevel                                   |
    | Chemistry   | Entry level - Skills for Life                        | 
    | Bricklaying | Level 1 - First certificate                          | 
    | Maths       | Level 2 - GCSE/O level                               | 
    | English     | Level 3 - A level/Access to higher education diploma |
    | Plumbing    | Level 4 - Certificate of higher education/HNC        |
    | Electronic  | Level 5 - Foundation degree/HND                      |
    | Medicine    | Level 6 - Degree/Graduate diploma                    |
    | Biology     | Level 7 - Masters Degree/Postgraduate diploma        |
    | Physics     | Level 8 - Doctorate/PhD                              | 


@DFC-4091
	Scenario Outline: DFC-4091 Search for Courses By Qualification Level Null Results
		Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I select qualification <QualificationLevel>
		And I click Search
		Then I should be on Search Results for page 
		And no results found message is displayed

  Examples:
    | CourseName | QualificationLevel            |
    | ARCHEOLOGY | Entry level - Skills for Life |

	
@DFC-3888
	Scenario Outline: DFC-3888 Search for Courses By Course Name All Options
		Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I select qualification <QualificationLevel>
		And I enter location <Location> 
		And I select distance <Distance>
		And I click Search
		Then I should be on Search Results for page

  Examples:
    | CourseName  | QualificationLevel                                   | Location | Distance |
    | Chemistry   | Entry level - Skills for Life                        | AB1 0AA  | 1 Mile   |
    | Bricklaying | Level 1 - First certificate                          | BB1 1AB  | 3 Miles  |
    | Maths       | Level 2 - GCSE/O level                               | CM0 7AE  | 5 Miles  |
    | English     | Level 3 - A level/Access to higher education diploma | G1 1AB   | 10 Miles |
    | Plumbing    | Level 4 - Certificate of higher education/HNC        | LS1 1AA  | 15 Miles |
    | Electronic  | Level 5 - Foundation degree/HND                      | ZE1 0AD  | 20 Miles |
    | Medicine    | Level 6 - Degree/Graduate diploma                    | SW10 0AA | National |
    | Biology     | Level 7 - Masters Degree/Postgraduate diploma        | b13 8py  | 3 Miles  |
    | Physics     | Level 8 - Doctorate/PhD                              | n1 0aj   | 5 Miles  |


@DFC-3888
	Scenario Outline: DFC-3888 Search for Courses By Course Name Only
		Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page

  Examples:
    | CourseName        |
    | Chemistry         |
    | chemsitry         |
    | CHEMISTRY         |
    | PLUMMING          |
    | Plumbing          |
    | PLUMING           |
    | BRICKLAYER        |
    | BRICK LAYER       |
    | hair and beuaty   |
    | Hair & Beauty     |
    | (Hair and Beuaty) |
    | hair-beuaty       |
    | a-level biology   |
    | A-LEVEL BIOLOGY   |
    | A Level Biology   |

@DFC-3888
	Scenario Outline: DFC-3888 Search for Courses By Course Name Null Results
		Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page
		And no results found message is displayed

  Examples:
    | CourseName  |
    | bbbbbbbbb   |
    | 1234567890  |
    | aaBBccDD123 |


@DFC-3883
	Scenario Outline: DFC-3883 Auto Populate Course Name
		Given I navigate to Find a Course home page
		When one letter at a time <CourseName>
		Then the Course suggestions <AutopopulateList> displayed
		And I Can select one of the List options <CourseName>
		When I click Search
		Then I should be on Search Results for page

  Examples:
    | CourseName | AutopopulateList                                                                                                      |
    | team       | TEAM,TEAM BUILDING,TEAM WORK,TEAM WORKING,TEAMWORK,TEAMWORKING                                                        |
    | builder    | BUILDER,BUILDING,BUILDING MAINTENANCE,BUILDING SERVICES,BUILDING SERVICES ENGINEERING,BUILDING SURVEYING,CONSTRUCTION |

	

@DFC-4094
Scenario: DFC-4094 Contact Adviser
	Given I navigate to Find a Course home page
	When I click Contact a Careers Advisor link
	Then I will be on Contact us page


@DFC-3887
Scenario: DFC-3887 View Qualification Level Help Text
	Given I navigate to Find a Course home page
	When I click What qualification levels mean link
	Then I will be on What qualification levels mean page