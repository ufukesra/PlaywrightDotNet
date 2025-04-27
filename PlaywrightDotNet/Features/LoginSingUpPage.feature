Feature: Login/SignUp 

#Login/SignUp Page Functionalities

Background: Landing page
    Given User navigates to landing page
    When  User clicks to SignUp_Login module

@login
Scenario: Verify user able to get error message with invalid credentials
    And   User enters invalid username
    When  User enters invalid password
    And   User clicks login button
    Then  User verifies the error message "Your email or password is incorrect!"

@registration
Scenario Outline: Verify user able to register successfully with valid credentials
    And  User enters name 
    When User enters valid email
    And  User clicks signUp button
    Then User validate account page "Enter Account Information"
    And  User select title
    When User enter password
    And  User enter DOB details
    When User checks the SignUp newslater checkbox
    And  User enters address Information
    When User click create account button
    Then User verifies successful registration with message "Account Created!"

    
        