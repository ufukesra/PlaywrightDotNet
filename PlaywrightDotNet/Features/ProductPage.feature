Feature: Product Page
#Product Page Functionalities

Background: Landing to the url
    Given User navigates to landing page

@product
Scenario: Verify user able search and filtering products
    When  User clicks to SignUp_Login module
    And   Enters valid email
    When  Enters valid password
    And   User clicks login button
    When  User manages to Product page and verifies with message "All Products"
    And  User enters "tshirts" and click search button
    When User filter brand POLO
    Then Verify products displayed based on selected brand