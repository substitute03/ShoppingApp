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

## Overview And Thoughts

- Separate domains are split out into separate projects for separation of concerns. Each project only has dependencies to the other project/s that it relies on.
- Wanted a balance between the app being "production code" to show what I can do, and applying [YAGNI](https://martinfowler.com/bliki/Yagni.html) principles to show how I think i.e. treating the task requirements as business requirements. Although this is slightly convoluted given the nature of the task!
  - For example, the `ProductRepository` returns a hard-coded list on products as the scope of the project did not require a database.
  - Bills are not saved as business requirements did not specify a need to do so, with no scope implied that it would be needed going forward.
- Specific scenarios described in the task PDF are commented in the unit tests.
- Methods have access modifiers only for the minimum amount of exposure needed.
