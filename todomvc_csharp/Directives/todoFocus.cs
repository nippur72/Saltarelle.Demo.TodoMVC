﻿using System;

using AngularJS;

namespace Todo
{
   /**
    * Directive that places focus on the element it is applied to when the expression it binds to evaluates to true
    */
   public class todoFocusDefinition : DirectiveDefinition
   {
      public todoFocusDefinition()
      {
         Name = "todoFocus";
         DirectiveController = typeof(todoFocusController);
      }        
   }

   public class todoFocusController : Scope
   {
      public Timeout timeout;          

      public todoFocusController(Timeout _timeout)
      {
         timeout = _timeout;        
      }

      public void Link(Scope _scope, /*AngularJS.Element*/ dynamic elem, Attributes attrs)
      {                  
         Watch<bool>(attrs["todoFocus"], (newValue, oldValue) =>
         {            
            if(newValue) 
            {
               timeout.Set( ()=>{elem[0].focus();} , 0, false);   
            }            
         });         
      }
   }
}



