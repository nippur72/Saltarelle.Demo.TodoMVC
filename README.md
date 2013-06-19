# Saltarelle.Demo.TodoMVC

This is the famous [TodoMVC](http://todomvc.com/) demo application 
for [AngularJS](http://angularjs.org) ported in C# using the [Saltarelle](http://www.saltarelle-compiler.com/) C# to Javascript compiler. 

I've made it as a benchmark for my new [AngularJS](https://github.com/nippur72/Saltarelle.AngularJS) metadata import library
that I'm writing for the Saltarelle compiler. With this library it will be possible to code in AngularJS using the C# language 
from the client side. (Unfortunately, as of now, the library is far from being complete, only the basic AngularJS objects are covered and
it's totally undocumented). 											

When porting the app, I tried to keep it as close as possible to the original Javascript implementation (which is included here for comparison). 

## How to run the App

The whole repo is a Visual Studio 2012 solution containing a website project and a C# project. You can load and run it in Visual Studio
using the integrated development web server, or you can just open it locally with your browser by opening the folder `Website`. 

What files to look for:

- `todo_original.html` is the original application launch page
- `todo_in_csharp.html` is ported C# application launch page (slightly modified to include the needed libraries)
- `Saltarelle.Angular.js` and `mscorlib.js` are the required libraries
- `todomvc.js` is the C# compiled file.

If you want make and idea on how is to write in C# and Angular, look for .cs files under the C# project: there you'll find 
Controllers, Directives and Services. They are almost self-explanatory (if you already know angular) which is a good excuse for
not documenting them :-).

- `Main.cs` is the application entry point where the angular module is created and registered with controllers, services and directives.
- `TodoItem.cs` is where the class for "Todo items" is created (remember C# is a typed language!).
- `todoStorage.cs` is the service used to store the todo list (in HTML5's local storage).
- `todoBlur.cs` is the directive used in the markup to manage focus lost
- `todoFocus.cs` is the directive used in the markup to auto focus on the input field.
- `TodoController.cs` is the main controller that does all the application logic.

## C# vs Javascript

Please note that when dealing with controllers there are slight differences between C# and Javascript:

- In Javascript controllers are functions, in C# they are classes. 
- In C# the `$scope` object is bound to the controller class itself (in other words, it's `this`) so there is no need to make direct reference to the scope. 
This is a good advantage that makes code much more readable than its Javascript equivalent.
- In C# injectable objects are passed as parameters to the class' constructor. They have to be saved 
as local objects if they are to be referenced outside of the constructor, in other methods of the same class. In Javascript this is not necessary because 
the "methods" are nested functions that share the variables of the "outer" container function. 
- In C# identifiers starting with `$` are not allowed, so to reference an angular builtin object like `$scope` the underscore character is 
used instead of the dollar sign (eg: `_scope`).



 












