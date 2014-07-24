using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AngularJS;

namespace Todo
{                
   /**
    * The main controller for the app. The controller:
    * - retrieves and persists the model via the todoStorage service
    * - exposes the model to the template and provides event handlers
    */
   public class TodoCtrl 
   {
      public TodoItem[] todos;
      public string newTodo;
      public TodoItem editedTodo;
      public object statusFilter;
      public int remainingCount;
      public int completedCount;
      public bool allChecked;
      
      // injected objects
      public Location location;
      public todoStorage Storage;      
      public filterFilter filter;           
      
      public TodoCtrl(Scope _scope, Location _location, todoStorage todoStorage, filterFilter filterFilter)
      {
	      this.Storage = todoStorage;
         this.filter = filterFilter;         
         this.location = _location;

         todos = Storage.get();      

	      newTodo = "";
	      editedTodo = null;

         _scope.Watch<object>(()=>todos, update, true);

	      if(location.Path == "") location.Path = "/";
	      	      
         _scope.Watch<string>(()=>location.Path, pathchanged);         
      }            

      public void update()
      {		           
         remainingCount = filter.Filter(todos, new { completed=false }).Length;
		   completedCount = todos.Length - remainingCount;
		   allChecked = remainingCount==0;
		   Storage.put(todos);
      }	

      public void pathchanged(string path, string oldpath)
      {       
         statusFilter = (path == "/active")    ? new { completed=false } : 
                        (path == "/completed") ? new { completed=true  } : null;	
      }
      
      public void addTodo() 
      {		  
         string newTodo = this.newTodo.Trim();         
                  
		   if(newTodo.Length==0) 
         {
			   return;
         }                    
         todos.Push(new TodoItem() { title=newTodo, completed=false });         
         this.newTodo = "";
		}

      public void editTodo(TodoItem todo) 
      {
		   editedTodo = todo;
	   }

      public void doneEditing(TodoItem todo) 
      {
		   editedTodo = null;
		   todo.title = todo.title.Trim();

   		if(todo.title=="") 
         {
			   removeTodo(todo);
		   }
	   }

	   public void removeTodo(TodoItem todo) 
      {		   
         todos.Splice(todos.IndexOf(todo), 1);     
	   }

	   public void clearCompletedTodos() 
      {
		   todos = todos.Filter( (val)=> { return !val.completed; } );   
	   }

      public void markAll(bool completed) 
      {
		   foreach(var todo in todos)
         {
            todo.completed = completed;
         }
   	}
   }      
}
   


