Feature: Logged in user adds product to the cart
As a logged in user
I want to Verify that I can add a product to the cart
@test
Scenario: Verify login and add to cart in the mobile app
Given the user has logged in to the mobile app
  And user verifies the page title
 When the user adds the <number> of product or products to the cart
 Then user can see the  <number> of product or products in the cart

  Examples: 
 | number |
 | 3      |