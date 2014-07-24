# Saltarelle.Demo.TodoMVC

This is the famous [TodoMVC](http://todomvc.com/) demo application ported in C# using the [Saltarelle](http://www.saltarelle-compiler.com/) 
C# to JavaScript compiler and the [Saltarelle.AngularJS](https://github.com/nippur72/Saltarelle.AngularJS) library 
for the Saltarelle compiler.

This port is based on the AngularJs TodoMVC implementation written by Christoph Burgdorf, Eric Bidelman, Jacob Mumm and Igor Minar. I just 
converted it from JavaScript to C#. I tried to keep it as close as possible to the original, which is also included here for comparison. 

The "original" is based on angular v1.0.7, while the C# version has been updated to angular v1.2.13. 

## How to run the App

The whole repo is a Visual Studio solution containing a website project and a C# project. You can load and run it in Visual Studio
using the integrated development web server, or you can just open it locally with your browser by opening the folder `Website`. If you
run it in Visual Studio, don't forget to mark the Website project as starting project and the `.html` file as starting page.

What files to look for:

- `todo_original.html` is the original application launch page
- `todo_in_csharp.html` is the ported C# application launch page (slightly modified to adapt to the library)
- `Saltarelle.Angular.js` and `mscorlib.js` are the required libraries
- `todomvc.js` is the C# compiled file.

If you want make and idea on how it's to write in C# and Angular, look for `.cs` files under the C# project: there you'll find 
Controllers, Directives and Services. They are almost self-explanatory (if you already know angular.js) which is a good excuse for
not documenting them :-).

- `Main.cs` is the application entry point where the angular module is created and registered with controllers, services and directives.
- `TodoItem.cs` is where the class for "Todo items" is created (remember C# is a typed language!).
- `todoStorage.cs` is the service used to store the todo list (in HTML5's local storage).
- `todoBlur.cs` is the directive used in the markup to manage focus lost.
- `todoFocus.cs` is the directive used in the markup to auto focus on the input field.
- `TodoController.cs` is the main controller that does all the application logic.

## C# vs JavaScript

Please note that when dealing with angular controllers there are slight differences between C# and Javascript:

- In Javascript controllers are functions, in C# they are classes. 
- Controller in C# needs to be referenced from HTML with the "controller as" syntax (eg:`ng-controller='MyController as ctrl'`)
- In C# injectable objects are passed as parameters to the class' constructor. They have to be saved 
as local objects if they are to be referenced outside of the constructor (in other methods of the class). In Javascript this is not necessary because 
the "methods" are nested functions that share the variables of the "outer" container function. 
- In C# identifiers starting with `$` are not allowed, so to reference an Angular builtin object like `$scope` the underscore character is 
used instead of the dollar sign (eg: `_scope`).

