//using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;

namespace BBDS.Helpers {
	public static class Enumerable {
	    public static IEnumerable<T> MoveDown<T>(this IEnumerable<T> source, int index) {
	        if (source == null) {
	            throw new ArgumentNullException("source");
	        }
	        T[] array = source.ToArray();
	        if (index == array.Length - 1) {
	            return source;
	        }
	        return Swap<T>(array, index, index + 1);
	    }
	
	    public static IEnumerable<T> MoveDown<T>(this IEnumerable<T> source, T item) {
	        if (source == null) {
	            throw new ArgumentNullException("source");
	        }
	        T[] array = source.ToArray();
	        int index = Array.FindIndex(array, i => i.Equals(item));
	        if (index == -1) {
	            throw new InvalidOperationException();
	        }
	        if (index == array.Length - 1) {
	            return source;
	        }
	        return Swap<T>(array, index, index + 1);
	    }
	
	    public static IEnumerable<T> MoveUp<T>(this IEnumerable<T> source, int index) {
	        if (source == null) {
	            throw new ArgumentNullException("source");
	        }
	        T[] array = source.ToArray();
	        if (index == 0) {
	            return source;
	        }
	        return Swap<T>(array, index - 1, index);
	    }
	
	    public static IEnumerable<T> MoveUp<T>(this IEnumerable<T> source, T item) {
	        if (source == null) {
	            throw new ArgumentNullException("source");
	        }
	        T[] array = source.ToArray();
	        int index = Array.FindIndex(array, i => i.Equals(item));
	        if (index == -1) {
	            throw new InvalidOperationException();
	        }
	        if (index == 0) {
	            return source;
	        }
	        return Swap<T>(array, index - 1, index);
	    }
	
	    public static IEnumerable<T> Swap<T>(this IEnumerable<T> source, int firstIndex, int secondIndex) {
	        if (source == null) {
	            throw new ArgumentNullException("source");
	        }
	        T[] array = source.ToArray();
	        return Swap<T>(array, firstIndex, secondIndex);
	    }
	
	    private static IEnumerable<T> Swap<T>(T[] array, int firstIndex, int secondIndex) {
	        if (firstIndex < 0 || firstIndex >= array.Length) {
	            throw new ArgumentOutOfRangeException("firstIndex");
	        }
	        if (secondIndex < 0 || secondIndex >= array.Length) {
	            throw new ArgumentOutOfRangeException("secondIndex");
	        }
	        T tmp = array[firstIndex];
	        array[firstIndex] = array[secondIndex];
	        array[secondIndex] = tmp;
	        return array;
	    }
	
	    public static IEnumerable<T> Swap<T>(this IEnumerable<T> source, T firstItem, T secondItem) {
	        if (source == null) {
	            throw new ArgumentNullException("source");
	        }
	        T[] array = source.ToArray();
	        int firstIndex = Array.FindIndex(array, i => i.Equals(firstItem));
	        int secondIndex = Array.FindIndex(array, i => i.Equals(secondItem));
	        return Swap(array, firstIndex, secondIndex);
	    }
	}
}