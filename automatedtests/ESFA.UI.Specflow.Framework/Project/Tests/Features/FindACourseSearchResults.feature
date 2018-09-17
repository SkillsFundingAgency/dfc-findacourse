Feature: Find A Course Search Results Page
	As a user
	I am able to view and use the Search Results
	

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
 Scenario Outline: DFC3900 View Search Results By Course Name display Course Title
 Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page
		And the course title <CourseTitle> is displayed

  Examples:
    | CourseName | CourseTitle |
    | Biology    | Biology     |
    | Chemistry  | Chemi       |


	@DFC-3900
 Scenario Outline: DFC3900 View Search Results By Course Name display Course Level
 Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page
		And the course level <CourseLevel> is displayed

  Examples:
    | CourseName                                      | CourseLevel |
    | Biology                                         |             |
    | Chemistry                                       | Level 6     |
    | ASTROPHYSICS                                    | Level 3     |
    | DENTISTRY                                       | Level 2     |
    | Diploma Level 1 Plumbing Studies                | Level 1     |
    | Pharmacy Clinical Services Professional Diploma | Level 4     |
    | SQA HND Marine Engineering Direct Entry         | Level 5     |
    | Integrated Masters Equine Science MSci          | Level 7     |


@DFC-3900
 Scenario Outline: DFC3900 View Search Results By Course Name display Study Mode
 Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page
		And the study mode <StudyMode> is displayed

  Examples:
    | CourseName          | StudyMode |
    | English             | Full Time |
    | hair and beauty     | Part Time |
    | Hair & Beauty Route | Flexible  |


@DFC-3900
 Scenario Outline: DFC3900 View Search Results By Course Name displays Attendance Mode
 Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page
		And the attendance mode <AttendanceMode> is displayed

  Examples:
    | CourseName                                                                       | AttendanceMode           |
    | science                                                                          | Classroom-based          |
    | General Data Protection Regulation (ONLINE)                                      | Online/Distance Learning |
    | Motor Vehicle Maintenance and Repair Apprenticeship at Level 2 (IMI Awards Ltd)) | Work based               |

@DFC-3900
 Scenario Outline: DFC3900 View Search Results By Course Name displays Attendance Pattern
 Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page
		And the attendance pattern <AttendancePattern> is displayed

  Examples:
    | CourseName                                | AttendancePattern         |
    | English                                   | Normal Working Hours      |
    | arabic                                    | Evening/Weekend           |
    | Assistant Accountant Apprentice - Level 3 | Day Release/Block Release |


@DFC-3900
 Scenario Outline: DFC3900 View Search Results By Course Name displays Provider
 Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page
		And the provider <Provider> is displayed
	
  Examples:
    | CourseName     | Provider                                        |
    | urdu           | Batley Girls' High School - Visual Arts College |
    | CYBER SECURITY | Walsall College                                 |
	

@DFC-3900
 Scenario Outline: DFC3900 View Search Results By Course Name displays Location
 Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page
		And the location <Location> is dispalyed
	
  Examples:
    | CourseName                                                     | Location                                  |
    | Biology                                                        | Clarence Street, Liverpool, L3 5TP        |
    | Chemistry                                                      | Central Avenue, Chatham Maritime, ME4 4TB |
    | Certificate/Diploma for Entry to the Uniformed Public Services | United Kingdom                            |


@DFC-3900
 Scenario Outline: DFC3900 View Search Results By Course Name displays Distance
 Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I enter location <Location>
		And I click Search
		Then I should be on Search Results for page
		And the distance <Distance> is displayed
	
  Examples:
    | CourseName | Location | Distance |
    | geography  | london   | 0.0      |




@DFC-3900
 Scenario Outline: DFC3900 View Search Results By Course Name displays Start Date and Duration
 Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I enter location <Location>
		And I click Search
		Then I should be on Search Results for page
		And the distance <Distance> is displayed
		And the start date <StartDate> is displayed
		And the duration <Duration> is displayed

     Examples:
    | CourseName | Location | Distance | StartDate         | Duration |
    | geography  | london   | 0.0      | 10 September 2018 | 2 Years  |

