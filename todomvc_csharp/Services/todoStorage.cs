﻿using System;

using System.Html;
using System.Serialization;

using AngularJS;

namespace Todo
{
   /**
    * Services that persists and retrieves TODOs from localStorage
    */  

   public class todoStorage
   {
      private const string STORAGE_ID = "todos-angularjs";

      public TodoItem[] get()
      {                  
         TodoItem[] items = Json.Parse<TodoItem[]>((string) Window.LocalStorage.GetItem(STORAGE_ID));
         if(items==null) items = new TodoItem[]{ };
         return items;
      }

      public void put(TodoItem[] todos)
      {
         Window.LocalStorage.SetItem(STORAGE_ID, Json.Stringify(todos));
      }
   }
}

