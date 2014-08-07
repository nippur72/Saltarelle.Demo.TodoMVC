(function() {
	'use strict';
	var $asm = {};
	global.Todo = global.Todo || {};
	ss.initAssembly($asm, 'todomvc');
	////////////////////////////////////////////////////////////////////////////////
	// ArrayExtensions
	var $ArrayExtensions = function() {
	};
	$ArrayExtensions.__typeName = 'ArrayExtensions';
	global.ArrayExtensions = $ArrayExtensions;
	////////////////////////////////////////////////////////////////////////////////
	// Todo.TodoApp
	var $Todo_TodoApp = function() {
	};
	$Todo_TodoApp.__typeName = 'Todo.TodoApp';
	$Todo_TodoApp.Main = function() {
		// The main TodoMVC app module
		var todoapp = angular.module('todomvc', []);
		// directives
		AngularJS.ModuleBuilder.Directive($Todo_todoBlurDirective).call(null, todoapp, []);
		AngularJS.ModuleBuilder.Directive($Todo_todoFocusDirective).call(null, todoapp, []);
		// services         
		AngularJS.ModuleBuilder.Service($Todo_todoStorage).call(null, todoapp, []);
		// controllers
		AngularJS.ModuleBuilder.Controller($Todo_TodoCtrl).call(null, todoapp, []);
	};
	global.Todo.TodoApp = $Todo_TodoApp;
	////////////////////////////////////////////////////////////////////////////////
	// Todo.todoBlurDirective
	var $Todo_todoBlurDirective = function() {
	};
	$Todo_todoBlurDirective.__typeName = 'Todo.todoBlurDirective';
	global.Todo.todoBlurDirective = $Todo_todoBlurDirective;
	////////////////////////////////////////////////////////////////////////////////
	// Todo.TodoCtrl
	var $Todo_TodoCtrl = function(_scope, _location, todoStorage, filterFilter) {
		this.todos = null;
		this.newTodo = null;
		this.editedTodo = null;
		this.statusFilter = null;
		this.remainingCount = 0;
		this.completedCount = 0;
		this.allChecked = false;
		this.location = null;
		this.Storage = null;
		this.filter = null;
		this.Storage = todoStorage;
		this.filter = filterFilter;
		this.location = _location;
		this.todos = this.Storage.get();
		this.newTodo = '';
		this.editedTodo = null;
		_scope.$watch(ss.mkdel(this, function() {
			return this.todos;
		}), ss.mkdel(this, this.update), true);
		if (this.location.path() === '') {
			this.location.path('/');
		}
		_scope.$watch(ss.mkdel(this, function() {
			return this.location.path();
		}), ss.mkdel(this, this.pathchanged));
	};
	$Todo_TodoCtrl.__typeName = 'Todo.TodoCtrl';
	global.Todo.TodoCtrl = $Todo_TodoCtrl;
	////////////////////////////////////////////////////////////////////////////////
	// Todo.todoFocusDirective
	var $Todo_todoFocusDirective = function(_timeout) {
		this.timeout = null;
		this.timeout = _timeout;
	};
	$Todo_todoFocusDirective.__typeName = 'Todo.todoFocusDirective';
	global.Todo.todoFocusDirective = $Todo_todoFocusDirective;
	////////////////////////////////////////////////////////////////////////////////
	// Todo.TodoItem
	var $Todo_TodoItem = function() {
		this.title = null;
		this.completed = false;
	};
	$Todo_TodoItem.__typeName = 'Todo.TodoItem';
	global.Todo.TodoItem = $Todo_TodoItem;
	////////////////////////////////////////////////////////////////////////////////
	// Todo.todoStorage
	var $Todo_todoStorage = function() {
	};
	$Todo_todoStorage.__typeName = 'Todo.todoStorage';
	global.Todo.todoStorage = $Todo_todoStorage;
	ss.initClass($ArrayExtensions, $asm, {});
	ss.initClass($Todo_TodoApp, $asm, {});
	ss.initClass($Todo_todoBlurDirective, $asm, {
		Link: function(_scope, elem, attrs) {
			elem.bind('blur', function(ev) {
				_scope.$apply(attrs['todoBlur']);
			});
		},
		GetDefinition: function() {
			var def = new AngularJS.DirectiveDefinitionHelper();
			def.$Link = ss.mkdel(this, this.Link);
			return def.ToDefinitionObject();
		}
	}, null, [AngularJS.IDirective]);
	ss.initClass($Todo_TodoCtrl, $asm, {
		update: function() {
			this.remainingCount = this.filter(this.todos, { completed: false }).length;
			this.completedCount = this.todos.length - this.remainingCount;
			this.allChecked = this.remainingCount === 0;
			this.Storage.put(this.todos);
		},
		pathchanged: function(path, oldpath) {
			this.statusFilter = ((path === '/active') ? { completed: false } : ((path === '/completed') ? { completed: true } : null));
		},
		addTodo: function() {
			var newTodo = this.newTodo.trim();
			if (newTodo.length === 0) {
				return;
			}
			var $t2 = this.todos;
			var $t1 = new $Todo_TodoItem();
			$t1.title = newTodo;
			$t1.completed = false;
			$t2.push($t1);
			this.newTodo = '';
		},
		editTodo: function(todo) {
			this.editedTodo = todo;
		},
		doneEditing: function(todo) {
			this.editedTodo = null;
			todo.title = todo.title.trim();
			if (todo.title === '') {
				this.removeTodo(todo);
			}
		},
		removeTodo: function(todo) {
			this.todos.splice(ss.indexOf(this.todos, todo), 1);
		},
		clearCompletedTodos: function() {
			this.todos = this.todos.filter(function(val) {
				return !val.completed;
			});
		},
		markAll: function(completed) {
			for (var $t1 = 0; $t1 < this.todos.length; $t1++) {
				var todo = this.todos[$t1];
				todo.completed = completed;
			}
		}
	});
	ss.initClass($Todo_todoFocusDirective, $asm, {
		Link: function(_scope, elem, attrs) {
			_scope.$watch(attrs['todoFocus'], ss.mkdel(this, function(newValue, oldValue) {
				if (newValue) {
					this.timeout(function() {
						elem[0].focus();
					}, 0, false);
				}
			}));
		},
		GetDefinition: function() {
			var def = new AngularJS.DirectiveDefinitionHelper();
			def.$Link = ss.mkdel(this, this.Link);
			return def.ToDefinitionObject();
		}
	}, null, [AngularJS.IDirective]);
	ss.initClass($Todo_TodoItem, $asm, {});
	ss.initClass($Todo_todoStorage, $asm, {
		get: function() {
			var items = JSON.parse(window.localStorage.getItem($Todo_todoStorage.$STORAGE_ID));
			if (ss.isNullOrUndefined(items)) {
				items = [];
			}
			return items;
		},
		put: function(todos) {
			window.localStorage.setItem($Todo_todoStorage.$STORAGE_ID, JSON.stringify(todos));
		}
	});
	$Todo_todoStorage.$STORAGE_ID = 'todos-angularjs';
})();
