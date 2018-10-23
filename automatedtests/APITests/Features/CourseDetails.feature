Feature: Course Details
	View Course Details

@APITests
Scenario Outline: View Course Deatils
	Given I have an endpoint Live Course Details
	When I view course details <courseId>
	Then the result contains course <course>

	Examples:
	| courseId | course    |
	| 54462473 | biology   |
	| 54856987 | chemistry |
	| 53975518 | physics   |
	| 54183269 | history   |
	

