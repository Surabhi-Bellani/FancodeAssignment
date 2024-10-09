Feature: FanCode User Task Completion

Scenario: Users from FanCode City have completed more than 50% of their tasks
   Given User belongs to FanCode city
   When user fetches their todo tasks
   Then User Completed task percentage should be greater than 50%

