Feature: Login/SignUp 

#Login/SignUp Page Functionalities

@login
Scenario: Verify user able to get error message with invalid credentials
	Given User navigates to landing page
    When  User clicks to SignUp_Login module
    And   User enters invalid username
    When  User enters invalid password
    And   User clicks login button
    Then  User verifies the error message "Your email or password is incorrect!"
