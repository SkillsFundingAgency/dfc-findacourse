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
    | CourseName                                                    | CourseLevel |
    | Biology                                                       |             |
    | Diploma in Chemical Skin Peeling & Micro-needling             | Level 4     |
    | ASTROPHYSICS                                                  | Level 3     |
    | DENTISTRY                                                     | Level 2     |
    | C&G L1 AWARD IN INTRODUCTORY TUNGSTEN INERT GAS (TIG) WELDING | Level 1     |
    | Pharmacy Clinical Services Professional Diploma               | Level 4     |
    | SQA HND Marine Engineering Direct Entry                       | Level 5     |
    | Integrated Masters Equine Science MSci                        | Level 7     |


@DFC-3900
 Scenario Outline: DFC3900 View Search Results By Course Name display Study Mode
 Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page
		And the study mode <StudyMode> is displayed

  Examples:
    | CourseName                                  | StudyMode |
    | A-level Maths (Pure and Statistics)         | Full Time |
    | hair and beauty                             | Part Time |
    | General Data Protection Regulation (ONLINE) | Flexible  |


@DFC-3900
 Scenario Outline: DFC3900 View Search Results By Course Name displays Attendance Mode
 Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page
		And the attendance mode <AttendanceMode> is displayed

  Examples:
    | CourseName                                     | AttendanceMode           |
    | A Level Biology or Human Biology               | Classroom-based          |
    | General Data Protection Regulation (ONLINE)    | Online/Distance Learning |
    | Management - Apprenticeship (Higher) - Level 4 | Work based               |


@DFC-3900
 Scenario Outline: DFC3900 View Search Results By Course Name displays Attendance Pattern
 Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page
		And the attendance pattern <AttendancePattern> is displayed

  Examples:
    | CourseName                                                   | AttendancePattern         |
    | NVQ 3 Diploma Nail Services - Day release (Apprentice Route) | Normal Working Hours      |
    | arabic                                                       | Evening/Weekend           |
    | Management - Apprenticeship (Higher) - Level 4               | Day Release/Block Release |


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
    | CourseName                                                     | Location |
    | Biology                                                        | L3 5TP   |
    | Chemistry                                                      | ME4 4TB  |
    | Certificate/Diploma for Entry to the Uniformed Public Services | United Kingdom  |


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
    | geography  | EC1A 1BB   | 6.9     |


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
    | geography  | EC1A 1BB   | 6.9      | 1 September 2018 | 2 Years  |


@DFC-3934
 Scenario Outline: DFC3935 Select location on Page 2
 Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I enter location <Location>
		And I click Search
		Then I should be on Search Results for page
		When On Page 2 I enter location <Location2>
		And On Page 2 I click Search
		Then I should be on Search Results for page

     Examples:
    | CourseName | Location | Location2 |
    | maths      | EC1A 1BB | BS1 1JG   |
    | english    | EC1A 1BB | NE7 7SF   |
    | biology    | EC1A 1BB | M9 0FN    |
    | computing  | EC1A 1BB | L4 1SE    |
    | history    | EC1A 1BB | S1 2HE    |
    | safety     | EC1A 1BB | BD1 1AJ   |



@DFC-3935
 Scenario Outline: DFC3935 Select Course Name on Page 2
 Given I navigate to Find a Course home page
		When I enter course <CourseName>
		And I click Search
		Then I should be on Search Results for page
		When On Page 2 I enter course <CourseName2>
		And On Page 2 I click Search
		Then I should be on Search Results for page

     Examples:
    | CourseName | CourseName2       |
    | geography  | biology           |
    | geography  | team building     |
    | geography  | NURSING           |
    | geography  | ENGINEERING       |
    | geography  | A LEVEL CHEMISTRY |
    | geography  | NVQ HAIR & BEAUTY |
    | geography  | GCSE MATHS        |
    | geography  | LEVEL 4 EDUCATION |
