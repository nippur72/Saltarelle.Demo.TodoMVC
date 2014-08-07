using System;

using AngularJS;

namespace Todo
{
   /**
    * Directive that places focus on the element it is applied to when the expression it binds to evaluates to true
    */
       
   public class todoFocusDirective : IDirective
   {
      public Timeout timeout;          

      public todoFocusDirective(Timeout _timeout)
      {
         timeout = _timeout;        
      }

      public void Link(Scope _scope, jElement elem, Attributes attrs)
      {                  
         _scope.Watch<bool>(attrs["todoFocus"], (newValue, oldValue) =>
         {            
            if(newValue) 
            {
               timeout.Set( ()=>{ elem[0].Focus(); }, 0, false);   
            }            
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



