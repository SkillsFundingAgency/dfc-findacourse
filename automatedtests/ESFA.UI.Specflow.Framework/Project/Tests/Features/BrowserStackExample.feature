Feature: BrowserStackTests
@BrowserStack
Scenario Outline: Can find search results
  Given I am on the google page for <profile> and <environment>
  When I search forr BrowserStack
  Then I should see title BrowserStack - Google Search
  
  Examples:
    | profile  | environment |
    | single   | chrome      |
    | parallel | chrome      |
    | parallel | firefox     |
    | parallel | safari      |
    | parallel | ie          |
