Feature: Cart Page
#Cart Functionalities

Background: Landing to the url
    Given User navigates to landing page

@cart
Scenario: User verifies adding products to chart and calculate total amount
    When  User clicks to SignUp_Login module
    And   Enters valid email
    When  Enters valid password
    And   User clicks login button
    When  User manage to Product Page
    And   User add products to chart
    When  User update product quantity
    And   User remove one product from cart
    Then  Verify total amount calculation correct