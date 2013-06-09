using System;
using System.Html;
using System.Html.Data;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;


/**
 * Some array extensions to work with arrays as in the original TodoMVC example app.
 *
 * Normally in Saltarelle, List<TodoItem> is preferred instead of TodoItem[], as
 * the first is more .NET like still compiles to Javascript array. 
 *
 * I've maintained TodoItem[] to make it more comparable to the original javascript TodoMVC implementation.
 *
 */

public static class ArrayExtensions
{   		     
   [InlineCode("{array}.push({*items})")]      
	public static int Push<T>(this T[] array, params T[] items) { return -1; }
                             		
   [InlineCode("{array}.splice({index},{howmany})")]      
	public static T[] Splice<T>(this T[] array, int index, int howmany) { return null; }
		
   [InlineCode("{array}.splice({index},{howmany},{*items})")]      
	public static T[] Splice<T>(this T[] array, int index, int howmany, params T[] items) { return null; }
}

