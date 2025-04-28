📖 PlaywrightDotNet Automation Framework

This project is an end-to-end UI Automation Framework built with Playwright for .NET, using C#, Reqnroll (SpecFlow alternative), and NUnit. It automates test scenarios for the Automation Exercise website.


🚀 Setup Instructions
    1- Clone the Repository

        $ git clone https://github.com/ufukesra/PlaywrightDotNet.git
        $ cd PlaywrightDotNet
    2- Install Dependencies

        .Make sure you have .NET SDK installed (version 7.0 or above).

        .Restore the NuGet packages:

            $ dotnet restore

    3- Install Playwright Browsers

        .Install required browsers for Playwright:

            $ playwright install
    4- Ensure Local Configuration

        .appsettings.json contains test configuration:

            {
            "UrlPath": "https://automationexercise.com/",
            "TestParameters": {
                "Username": "wrongUsername@mail.com",
                "Password": "WrongPassword+",
                "Username2": "automationexercise1000@gmail.com",
                "Password2": "Test1234?"
            }
            }



🧪 Test Execution Commands
    1- Run all tests:
        $ dotnet test

    2- Run a specific feature file:
        $ dotnet test --filter "FullyQualifiedName~PlaywrightDotNet.Features.CartPageFeature"
    
    3- Generate Test Report (optional with a reporting plugin):
        $ dotnet test --logger "trx;LogFileName=TestResults.trx"



🏛️ Test Architecture and Patterns
    
    1- Framework Structure

        /Features         → Gherkin feature files
        /StepDefinitions  → Step Definitions linking Gherkin to Playwright
        /Pages            → Page Object Model classes for pages
        /Utilities        → Configuration handling, Test data builders
        /TestDataBuilders → Dynamic Test Data generation (using Bogus)
    
    2- Key Design Patterns

        .Page Object Model (POM): Encapsulates UI interactions in page classes for reusability.

        .SpecFlow/Reqnroll with Gherkin: For Behavior Driven Development (BDD) style clear scenarios.

        .Test Data Builder: Dynamic creation of test users using Bogus library.



💡 Reasoning Behind Key Decisions
    1- Playwright with C#: Powerful cross-browser automation with native async/await support in C#.

    2- Bogus for Dynamic Data: Avoids hard-coded test data, enables dynamic user registration.

    3- Reqnroll instead of SpecFlow: Modern lightweight alternative, faster build times.

    4- Page Object Model: Reduces duplication and improves maintainability.

    5- Configuration Class: Centralized config reading from appsettings.json, environment-agnostic setup.



🧗 Challenges Encountered and Solutions

    Challenges --> Solutions
        1- Element becoming visible but dropdown options missing    --> Added retry mechanisms and explicit waits before selecting options.

        2- Timeout errors during element interaction    -->	Used WaitForSelectorAsync and improved locators to make them more resilient.

        3- Dynamic Test Data Generation Error  --> Added async-safe generation for Faker (Bogus) and isolated static methods for consistent random data creation.

        4- Missing or accidentally discarded files (e.g., Bogus imports)    --> Re-added manually via tracking recent commits and folder structure cleanup.
        
        5- JSON parsing issue (Username2, Password2)    --> Fixed by properly matching object structure in Configuration class and using nested TestParameters.


🚀 How I Would Improve It If Given More Time

    1- Add Allure or Extent Reports for prettier HTML-based test reports.

    2- Cross-browser testing (Chrome, Firefox, Safari) integrated into CI/CD.

    3- Parallel Test Execution to speed up large test suites.

    4- Better Error Handling: Retry policies for flaky UI elements.

    5- Integrate GitHub Actions / Azure Pipelines for automatic test runs on PRs.

    6- Visual Testing: Add Playwright's screenshot comparison.

    7- Environment Switching: Use environment-based config (e.g., staging, QA, production).

    8- Custom HTML Reporter: Generate customizable reports.


📌 Important Notes

    1-Inline code comments were added in complex areas such as:

    2-Locating dynamic elements

    3- Waiting for element states

    4- Data generation using Bogus

    5- Configuration reading and binding

    6- Always make sure appsettings.json exists in the output directory if running tests via CLI.

    7- Use meaningful commit messages to avoid confusion in the future (learned the hard way 😉).

🛠 Technologies Used
    
    - C#

    - Playwright for .NET

    - NUnit

    - Reqnroll

    - Bogus (Test Data Generator)

    - Microsoft.Extensions.Configuration

🙋 Author
Ufuk Sahinduran




## ✍️ Originality Statement

This project is entirely my own work. 

I developed the framework architecture, test scenarios, and code implementation independently. I used official documentation for Playwright for .NET, NUnit, and Bogus libraries to understand syntax and capabilities.

No external frameworks, templates, or copied repositories were used.  
Any third-party libraries utilized (such as Playwright, Reqnroll, and Bogus) are properly referenced and used according to their official documentation.
