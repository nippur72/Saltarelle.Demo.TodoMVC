using System;
using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

// this attribute turns off the compiler option that outputs camelCase names
[assembly: PreserveMemberCase]

namespace Todo
{
   public class TodoApp
   {
      public static void Main()
      {
         // The main TodoMVC app module
         Module todoapp = new Module("todomvc");
         
         // directives
         todoapp.Directive<todoBlurDirective>();         
         todoapp.Directive<todoFocusDirective>();        
                  
         // services         
         todoapp.Service<todoStorage>();  
         
         // controllers
         todoapp.Controller<TodoCtrl>();
      }
   }
}
