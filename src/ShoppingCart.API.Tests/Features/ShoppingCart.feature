Feature: ShoppingCart

Background: 
	Given there are products with the following data
	| Id | Name      | Price |
	| 1  | Product A | 10.99 |
	| 2  | Product B | 25.50 |

@Item
Scenario: Add an item to a shopping cart
	Given a new shopping cart is created
	When add 1 item of product 1 to the shopping cart
	Then the shopping cart total amount should be 10.99

@Item
Scenario: Increase a quantity of an item in a shopping cart
	Given a new shopping cart is created with the following data
	| ProductId | Quantity |
	| 1         | 1        |
	| 2         | 1        |
	When add 1 item of product 1 to the shopping cart
	Then the shopping cart total amount should be 47.48

@Item
Scenario: Remove an item from a shopping cart
	Given a new shopping cart is created with the following data
	| ProductId | Quantity |
	| 1         | 1        | 
	| 2         | 1        |
	When remove 1 item of product 1 from the shopping cart
	Then the shopping cart total amount should be 25.50

@Item
Scenario: Decrease a quantity of an item in a shopping cart
	Given a new shopping cart is created with the following data
	| ProductId | Quantity |
	| 1         | 2        |
	| 2         | 1        |
	When remove 1 item of product 1 from the shopping cart
	Then the shopping cart total amount should be 36.49

@Item
Scenario: Remove all items from a shopping cart
	Given a new shopping cart is created with the following data
	| ProductId | Quantity |
	| 1         | 1        | 
	| 2         | 1        |
	When remove 1 item of product 1 from the shopping cart
	And remove 1 item of product 2 from the shopping cart
	Then the shopping cart total amount should be 0.00

@ShoppingCart
Scenario: Delete a shopping cart
	Given a new shopping cart is created
	When delete the shopping cart
	Then the shopping cart should not exist
