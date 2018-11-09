Feature: Course Directory Search
	Search the Course Directory

@APITests
Scenario Outline: Search on Course Name Only
	Given I have an endpoint Live Course Search
	When I search for course <coursename>
	Then the result contains course <coursename>

	Examples:
	| coursename    |
	| maths         |
	| History       |
	| cybersecurity |
	| BIOLOGY       |
	| ENGLISH       |

@APITests
Scenario Outline: Search on Invalid Course Name
	Given I have an endpoint Live Course Search
	When I search for course <coursename>
	Then the result do not contain course <coursename>

	Examples:
	| coursename      |
	| bbbbbbb         |
	| @chemistry      |
	| cyber*          |
	| Chemistry!      |
	| chemsitry;      |
	| CHEMISTRY^      |
	| {PLUMING}       |
	| BRICK=LAYER     |
	| hairbeuaty?     |
	| Hair%           |
	| [HairBeauty]    |
	| A~LEVEL BIOLOGY |
	| hair_beauty     |

@APITests
Scenario Outline: Search on Course Name and Qualification Level
	Given I have an endpoint Live Course Search
	When I search for courses with qaulification level <coursename> , <level>
	Then the result contains course <coursename>
	Then the result contains course <level>

	Examples:
	| coursename  | level |
	| biology     | 3     |
	| biology     | 2     |
	| english     | 1     |
	| english     | 0     |
	| engineering | 4     |
	| engineering | 5     |
	| Management  | 7     |


@APITests
Scenario Outline: Search on Course Name and Postcode
	Given I have an endpoint Live Course Search
	When I search for courses with postcode <coursename> , <postcode>
	Then the result contains course <coursename>

	Examples:
	| coursename | postcode |
	| biology    | b13 9da  |


@APITests
Scenario Outline: Search on Course Name and Postcode with Distance
	Given I have an endpoint Live Course Search
	When I search for courses with distance and postcode <coursename> , <postcode> , <distance>
	Then the result contains course <coursename>

	Examples:
	| coursename | postcode | distance |
	| esol       | b13 9da  | 1        |
	| english    | b13 9da  | 3        |
	| english    | b13 9da  | 10       |
	| english    | b13 9da  | 15       |
	| english    | b13 9da  | 20       |
	| english    | b13 9da  | 1000     |


@APITests
Scenario Outline: Search on Course Name and Qualification Level and Postcode
	Given I have an endpoint Live Course Search
	When I search for courses with level and postcode <coursename> , <level> , <postcode>
	Then the result contains course <coursename>
	Then the result contains course <level>

	Examples:
	| coursename | level | postcode |
	| english    | 3     | b13 9da  |
