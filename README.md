# ShoppingApp

ShoppingApp is a simple console application developed in .NET Core 3.1 that allows you to add items to shopping basket, have special offers applied, and to generate a bill. To run the app, simply open the solution and run it. There are no additional dependencies.

## Commands

- **/help** - Displays a list of options.
- **/products** - Displays a list of available products.
- **/basket** - Displays the contents of your shopping basket.
- **/add** - Allows you to specify a product and a quantity to add to your shopping basket.
- **/remove** - Allows you to specify a product and a quantity to remove from your shopping basket.
- **/cancel** - Cancels out of a transaction.
- **/checkout** - Completes the shopping transaction and generates a bill based on the contents of your basket.

## Examples

To add 2 bread and 2 soup to your basket, and then checkout, you would execute the following commands.
```
1. /add
2. bread
3. 2
4. /add
5. soup
6. 2
7. /checkout
```

To remove 1 soup before checking out you would execute the following commands.
```
1. /remove
2. soup
3. 1
5. /checkout
```
