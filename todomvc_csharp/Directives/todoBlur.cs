using System;

using AngularJS;

namespace Todo
{
   /**
    * Directive that executes an expression when the element it is applied to loses focus
    */

   public class todoBlurDirective : IDirective
   {
      public void Link(Scope _scope, jElement elem, Attributes attrs)
      {         
         elem.bind("blur",(ev)=>
         {
            _scope.Apply<string>(attrs["todoBlur"]);
         });            
      }

      public DefinitionObject GetDefinition()
      {
         var def = new DirectiveDefinitionHelper();           
         def.LinkFunction(this.Link);    
         return def.ToDefinitionObject();
      }
   }
}



