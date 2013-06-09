using System;

using AngularJS;

namespace Todo
{
   /**
    * Directive that executes an expression when the element it is applied to loses focus
    */

   public class todoBlurDefinition : DirectiveDefinition
   {
      public todoBlurDefinition()
      {
         Name = "todoBlur";        
         DirectiveController = typeof(todoBlurController);
      }
   }

   public class todoBlurController : Scope
   {      
      public void Link(Scope _scope, Element elem, Attributes attrs)
      {         
         elem.bind("blur",()=>
         {
            Apply<string>(attrs["todoBlur"]);
         });         
      }
   }
}



