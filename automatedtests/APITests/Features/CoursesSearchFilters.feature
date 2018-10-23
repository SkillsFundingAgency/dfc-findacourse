Feature: Course Directory Search Filters
	Filter Course Directory Search results

@APITests
Scenario Outline: Filter by Study Mode
	Given I have an endpoint Live Course Search
	When I search and filter results by Study Mode <coursename> , <studymode>
	Then the result contains course <coursename>

	Examples:
	| coursename | studymode |
	| ENGLISH    | 1         |
	| ENGLISH    | 2         |
	| ENGLISH    | 3         |
	| ENGLISH    | all       |


@APITests
Scenario Outline: Filter by Attendance Mode
	Given I have an endpoint Live Course Search
	When I search and filter results by Attendance Mode <coursename> , <attendancemode>
	Then the result contains course <coursename>

	Examples:
	| coursename | attendancemode |
	| ENGLISH    | 1              |
	| ENGLISH    | 2              |
	| ENGLISH    | 3              |
	| ENGLISH    | all            |


@APITests
Scenario Outline: Filter by Attendance Pattern
	Given I have an endpoint Live Course Search
	When I search and filter results by Attendance Pattern <coursename> , <attendancepattern>
	Then the result contains course <coursename>

	Examples:
	| coursename | attendancepattern |
	| ENGLISH    | 1                 |
	| ENGLISH    | 2                 |
	| ENGLISH    | 3                 |
	| ENGLISH    | all               |


@APITests
Scenario Outline: Filter by Qualification Level
	Given I have an endpoint Live Course Search
	When I search and filter results by Qualification Level <coursename> , <level>
	Then the result contains course <coursename>

	Examples:
	| coursename | level |
	| ENGLISH    | 1     |
	| ENGLISH    | 2     |
	| ENGLISH    | 3     |
	| ENGLISH    | 4     |
	| ENGLISH    | 5     |
	| CHEMISTRY  | 6     |
	| MANAGEMENT | 7     |
	| TELECOMS   | 8     |
	| ENGLISH    | 0     |
	| ENGLISH    | all   |


@APITests
Scenario Outline: Filter by DFE Funded
	Given I have an endpoint Live Course Search
	When I search and filter results by DFE Funded <coursename> , <dfefunded>
	Then the result contains course <coursename>

	Examples:
	| coursename | dfefunded |
	| ENGLISH    | true      |
	| ENGLISH    | false     |
	| ENGLISH    | all       |