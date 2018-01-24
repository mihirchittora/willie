﻿//
// THIS FILE IS AUTOGENERATED - DO NOT EDIT
// In order to make changes make sure to edit the t4 template file (*.tt)
//

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
    	
        /// <summary>
        /// Computes the Median of a sequence of mullable int values, or null if the source sequence is
        ///     empty or contains only values that are null.
        /// </summary>
        /// <param name="source">A sequence of nullable int values to calculate the Median of.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double? Median(this IEnumerable<int?> source)
        {
            IEnumerable<int> values = source.AllValues();
            if (values.Any())
                return values.Median();

            return null;
        }

        /// <summary>
        /// Computes the Median of a sequence of int values.
        /// </summary>
        /// <param name="source">A sequence of int values to calculate the Median of.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double Median(this IEnumerable<int> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var sortedList = (from number in source
                             orderby number
                             select (double)number).ToList();

            int count = sortedList.Count;
            int itemIndex = count / 2;

            if (count % 2 == 0)
            {
                // Even number of items.
                return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / (double)2;
            }

            // Odd number of items.
            return sortedList[itemIndex];
        }

        /// <summary>
        ///     Computes the Median of a sequence of nullable int values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double? Median<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Median();
        }

        /// <summary>
        ///     Computes the Median of a sequence of int values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double Median<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Median();
        }
 	
        /// <summary>
        /// Computes the Median of a sequence of mullable long values, or null if the source sequence is
        ///     empty or contains only values that are null.
        /// </summary>
        /// <param name="source">A sequence of nullable long values to calculate the Median of.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double? Median(this IEnumerable<long?> source)
        {
            IEnumerable<long> values = source.AllValues();
            if (values.Any())
                return values.Median();

            return null;
        }

        /// <summary>
        /// Computes the Median of a sequence of long values.
        /// </summary>
        /// <param name="source">A sequence of long values to calculate the Median of.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double Median(this IEnumerable<long> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var sortedList = (from number in source
                             orderby number
                             select (double)number).ToList();

            int count = sortedList.Count;
            int itemIndex = count / 2;

            if (count % 2 == 0)
            {
                // Even number of items.
                return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / (double)2;
            }

            // Odd number of items.
            return sortedList[itemIndex];
        }

        /// <summary>
        ///     Computes the Median of a sequence of nullable long values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double? Median<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Median();
        }

        /// <summary>
        ///     Computes the Median of a sequence of long values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double Median<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Median();
        }
 	
        /// <summary>
        /// Computes the Median of a sequence of mullable decimal values, or null if the source sequence is
        ///     empty or contains only values that are null.
        /// </summary>
        /// <param name="source">A sequence of nullable decimal values to calculate the Median of.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static decimal? Median(this IEnumerable<decimal?> source)
        {
            IEnumerable<decimal> values = source.AllValues();
            if (values.Any())
                return values.Median();

            return null;
        }

        /// <summary>
        /// Computes the Median of a sequence of decimal values.
        /// </summary>
        /// <param name="source">A sequence of decimal values to calculate the Median of.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static decimal Median(this IEnumerable<decimal> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var sortedList = (from number in source
                             orderby number
                             select (decimal)number).ToList();

            int count = sortedList.Count;
            int itemIndex = count / 2;

            if (count % 2 == 0)
            {
                // Even number of items.
                return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / (decimal)2;
            }

            // Odd number of items.
            return sortedList[itemIndex];
        }

        /// <summary>
        ///     Computes the Median of a sequence of nullable decimal values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static decimal? Median<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Median();
        }

        /// <summary>
        ///     Computes the Median of a sequence of decimal values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static decimal Median<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Median();
        }
 	
        /// <summary>
        /// Computes the Median of a sequence of mullable float values, or null if the source sequence is
        ///     empty or contains only values that are null.
        /// </summary>
        /// <param name="source">A sequence of nullable float values to calculate the Median of.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static float? Median(this IEnumerable<float?> source)
        {
            IEnumerable<float> values = source.AllValues();
            if (values.Any())
                return values.Median();

            return null;
        }

        /// <summary>
        /// Computes the Median of a sequence of float values.
        /// </summary>
        /// <param name="source">A sequence of float values to calculate the Median of.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static float Median(this IEnumerable<float> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var sortedList = (from number in source
                             orderby number
                             select (float)number).ToList();

            int count = sortedList.Count;
            int itemIndex = count / 2;

            if (count % 2 == 0)
            {
                // Even number of items.
                return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / (float)2;
            }

            // Odd number of items.
            return sortedList[itemIndex];
        }

        /// <summary>
        ///     Computes the Median of a sequence of nullable float values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static float? Median<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Median();
        }

        /// <summary>
        ///     Computes the Median of a sequence of float values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static float Median<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Median();
        }
 	
        /// <summary>
        /// Computes the Median of a sequence of mullable double values, or null if the source sequence is
        ///     empty or contains only values that are null.
        /// </summary>
        /// <param name="source">A sequence of nullable double values to calculate the Median of.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double? Median(this IEnumerable<double?> source)
        {
            IEnumerable<double> values = source.AllValues();
            if (values.Any())
                return values.Median();

            return null;
        }

        /// <summary>
        /// Computes the Median of a sequence of double values.
        /// </summary>
        /// <param name="source">A sequence of double values to calculate the Median of.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double Median(this IEnumerable<double> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var sortedList = (from number in source
                             orderby number
                             select (double)number).ToList();

            int count = sortedList.Count;
            int itemIndex = count / 2;

            if (count % 2 == 0)
            {
                // Even number of items.
                return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / (double)2;
            }

            // Odd number of items.
            return sortedList[itemIndex];
        }

        /// <summary>
        ///     Computes the Median of a sequence of nullable double values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double? Median<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Median();
        }

        /// <summary>
        ///     Computes the Median of a sequence of double values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double Median<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Median();
        }
     }
}