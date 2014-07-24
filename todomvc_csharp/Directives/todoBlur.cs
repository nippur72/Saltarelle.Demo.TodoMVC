using System;

using AngularJS;

namespace Todo
{
   /**
    * Directive that executes an expression when the element it is applied to loses focus
    */

   public class todoBlurDirective : IDirective
   {
      public DefinitionObject GetDefinition()
      {
         var def = new DirectiveDefinitionHelper();  
         def.Controller<todoBlurController>();    
         return def.ToDefinitionObject();
      }
   }

   public class todoBlurController 
   {      
      public void Link(Scope _scope, Element elem, Attributes attrs)
      {         
         elem.bind("blur",()=>
         {
            _scope.Apply<string>(attrs["todoBlur"]);
         });         
      }
   }
}



