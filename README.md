# ShoppingApp
ShoppingApp is a simple console application that allows you to add items to shopping basket, have special offers applied, and to generate a bill.

## Commands

- **/help** - Displays a list of options.
- **/products** - Displays a list of available products.
- **/basket** - Displays the contents of your shopping basket.
- **/add** - Allows you to specify a product and a quantity to add to your shopping basket.
- **/confirm** - Used to confirm the product selection to be added or removed to or from your shopping basket at the end of an **/add** command.
- **/checkout** - Completes the shopping transaction and generates a bill based on the contents of your basket.

## Example

To add 2 bread and 2 soup to your basket, and then checkout, you would execute the following commands.
```
1. /add
2. bread
3. 2
4. /confirm
5. /add
6. soup
7. 2
8. /confirm
9. /checkout
```

To remove 1 soup before checking out you would execute the following commands.
```
1. /remove
2. soup
3. 1
4. /confirm
5. /checkout
```