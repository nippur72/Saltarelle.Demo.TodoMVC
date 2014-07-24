using System;

using AngularJS;

namespace Todo
{
   /**
    * Directive that places focus on the element it is applied to when the expression it binds to evaluates to true
    */
       
   public class todoFocusDirective : IDirective
   {
      public DefinitionObject GetDefinition()
      {
         var def = new DirectiveDefinitionHelper();  
         def.Controller<todoFocusController>();    
         return def.ToDefinitionObject();
      }           
   }

   public class todoFocusController 
   {
      public Timeout timeout;          

      public todoFocusController(Timeout _timeout)
      {
         timeout = _timeout;        
      }

      public void Link(Scope _scope, /*AngularJS.Element*/ dynamic elem, Attributes attrs)
      {                  
         _scope.Watch<bool>(attrs["todoFocus"], (newValue, oldValue) =>
         {            
            if(newValue) 
            {
               timeout.Set( ()=>{elem[0].focus();} , 0, false);   
            }            
         });         
      }
   }
}



