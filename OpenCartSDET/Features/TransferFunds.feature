Feature: Fund Transfer

  As a banking user
  I want to transfer funds between accounts
  So that balances are updated correctly

  Scenario: Successful fund transfer updates balances
    Given the user logs into Parabank
    And the user captures initial account balances
    When the user transfers 100 dollars
    Then the transfer should be successful
    And account balances should be updated correctly