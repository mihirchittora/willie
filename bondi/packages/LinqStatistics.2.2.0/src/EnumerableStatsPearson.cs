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
        /// Computes the Pearson of two sequences of nullable int values.
        /// </summary>
        /// <param name="source">The first sequence of nullable int values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of nullable int values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static double? Pearson(this IEnumerable<int?> source, IEnumerable<int?> other)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.Pearson(other.AllValues());

            return null;
        }

        /// <summary>
        /// Computes the Pearson of two sequences of int values.
        /// </summary>
        /// <param name="source">The first sequence of int values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of int values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static double Pearson(this IEnumerable<int> source, IEnumerable<int> other)
        {
            return source.Covariance(other) / (source.StandardDeviationP() * other.StandardDeviationP());
        }

        /// <summary>
        /// Computes the Pearson of the Item values of a sequence of Tuple{int, int} values.
        /// </summary>
        /// <param name="source">The type of the Tuple's Items.</param>
        /// <returns>The Pearson value.</returns>
        public static double Pearson(this IEnumerable<Tuple<int, int>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var x = source.Select(t => t.Item1);
            var y = source.Select(t => t.Item2);

            return x.Covariance(y) / (x.StandardDeviationP() * y.StandardDeviationP());
        }
        
        /// <summary>
        ///     Computes the Pearson of a sequence of nullable int values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The first sequence of int values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of int values to calculate the Pearson of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Pearson of the sequence of values.</returns>
        public static double? Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, int?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

             if (other == null)
                throw new ArgumentNullException("other");

           if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Pearson(other.Select(selector));
        }

        /// <summary>
        ///     Computes the Pearson of a sequence of nullable int values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The first sequence of int values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of int values to calculate the Pearson of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Pearson of the sequence of values.</returns>
        public static double Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, int> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (other == null)
                throw new ArgumentNullException("other");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Pearson(other.Select(selector));
        }
 	
        /// <summary>
        /// Computes the Pearson of two sequences of nullable long values.
        /// </summary>
        /// <param name="source">The first sequence of nullable long values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of nullable long values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static double? Pearson(this IEnumerable<long?> source, IEnumerable<long?> other)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.Pearson(other.AllValues());

            return null;
        }

        /// <summary>
        /// Computes the Pearson of two sequences of long values.
        /// </summary>
        /// <param name="source">The first sequence of long values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of long values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static double Pearson(this IEnumerable<long> source, IEnumerable<long> other)
        {
            return source.Covariance(other) / (source.StandardDeviationP() * other.StandardDeviationP());
        }

        /// <summary>
        /// Computes the Pearson of the Item values of a sequence of Tuple{long, long} values.
        /// </summary>
        /// <param name="source">The type of the Tuple's Items.</param>
        /// <returns>The Pearson value.</returns>
        public static double Pearson(this IEnumerable<Tuple<long, long>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var x = source.Select(t => t.Item1);
            var y = source.Select(t => t.Item2);

            return x.Covariance(y) / (x.StandardDeviationP() * y.StandardDeviationP());
        }
        
        /// <summary>
        ///     Computes the Pearson of a sequence of nullable long values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The first sequence of long values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of long values to calculate the Pearson of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Pearson of the sequence of values.</returns>
        public static double? Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, long?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

             if (other == null)
                throw new ArgumentNullException("other");

           if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Pearson(other.Select(selector));
        }

        /// <summary>
        ///     Computes the Pearson of a sequence of nullable long values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The first sequence of long values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of long values to calculate the Pearson of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Pearson of the sequence of values.</returns>
        public static double Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, long> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (other == null)
                throw new ArgumentNullException("other");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Pearson(other.Select(selector));
        }
 	
        /// <summary>
        /// Computes the Pearson of two sequences of nullable decimal values.
        /// </summary>
        /// <param name="source">The first sequence of nullable decimal values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of nullable decimal values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static decimal? Pearson(this IEnumerable<decimal?> source, IEnumerable<decimal?> other)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.Pearson(other.AllValues());

            return null;
        }

        /// <summary>
        /// Computes the Pearson of two sequences of decimal values.
        /// </summary>
        /// <param name="source">The first sequence of decimal values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of decimal values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static decimal Pearson(this IEnumerable<decimal> source, IEnumerable<decimal> other)
        {
            return source.Covariance(other) / (source.StandardDeviationP() * other.StandardDeviationP());
        }

        /// <summary>
        /// Computes the Pearson of the Item values of a sequence of Tuple{decimal, decimal} values.
        /// </summary>
        /// <param name="source">The type of the Tuple's Items.</param>
        /// <returns>The Pearson value.</returns>
        public static decimal Pearson(this IEnumerable<Tuple<decimal, decimal>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var x = source.Select(t => t.Item1);
            var y = source.Select(t => t.Item2);

            return x.Covariance(y) / (x.StandardDeviationP() * y.StandardDeviationP());
        }
        
        /// <summary>
        ///     Computes the Pearson of a sequence of nullable decimal values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The first sequence of decimal values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of decimal values to calculate the Pearson of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Pearson of the sequence of values.</returns>
        public static decimal? Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, decimal?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

             if (other == null)
                throw new ArgumentNullException("other");

           if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Pearson(other.Select(selector));
        }

        /// <summary>
        ///     Computes the Pearson of a sequence of nullable decimal values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The first sequence of decimal values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of decimal values to calculate the Pearson of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Pearson of the sequence of values.</returns>
        public static decimal Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, decimal> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (other == null)
                throw new ArgumentNullException("other");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Pearson(other.Select(selector));
        }
 	
        /// <summary>
        /// Computes the Pearson of two sequences of nullable float values.
        /// </summary>
        /// <param name="source">The first sequence of nullable float values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of nullable float values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static float? Pearson(this IEnumerable<float?> source, IEnumerable<float?> other)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.Pearson(other.AllValues());

            return null;
        }

        /// <summary>
        /// Computes the Pearson of two sequences of float values.
        /// </summary>
        /// <param name="source">The first sequence of float values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of float values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static float Pearson(this IEnumerable<float> source, IEnumerable<float> other)
        {
            return source.Covariance(other) / (source.StandardDeviationP() * other.StandardDeviationP());
        }

        /// <summary>
        /// Computes the Pearson of the Item values of a sequence of Tuple{float, float} values.
        /// </summary>
        /// <param name="source">The type of the Tuple's Items.</param>
        /// <returns>The Pearson value.</returns>
        public static float Pearson(this IEnumerable<Tuple<float, float>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var x = source.Select(t => t.Item1);
            var y = source.Select(t => t.Item2);

            return x.Covariance(y) / (x.StandardDeviationP() * y.StandardDeviationP());
        }
        
        /// <summary>
        ///     Computes the Pearson of a sequence of nullable float values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The first sequence of float values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of float values to calculate the Pearson of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Pearson of the sequence of values.</returns>
        public static float? Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, float?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

             if (other == null)
                throw new ArgumentNullException("other");

           if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Pearson(other.Select(selector));
        }

        /// <summary>
        ///     Computes the Pearson of a sequence of nullable float values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The first sequence of float values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of float values to calculate the Pearson of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Pearson of the sequence of values.</returns>
        public static float Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, float> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (other == null)
                throw new ArgumentNullException("other");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Pearson(other.Select(selector));
        }
 	
        /// <summary>
        /// Computes the Pearson of two sequences of nullable double values.
        /// </summary>
        /// <param name="source">The first sequence of nullable double values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of nullable double values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static double? Pearson(this IEnumerable<double?> source, IEnumerable<double?> other)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.Pearson(other.AllValues());

            return null;
        }

        /// <summary>
        /// Computes the Pearson of two sequences of double values.
        /// </summary>
        /// <param name="source">The first sequence of double values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of double values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static double Pearson(this IEnumerable<double> source, IEnumerable<double> other)
        {
            return source.Covariance(other) / (source.StandardDeviationP() * other.StandardDeviationP());
        }

        /// <summary>
        /// Computes the Pearson of the Item values of a sequence of Tuple{double, double} values.
        /// </summary>
        /// <param name="source">The type of the Tuple's Items.</param>
        /// <returns>The Pearson value.</returns>
        public static double Pearson(this IEnumerable<Tuple<double, double>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var x = source.Select(t => t.Item1);
            var y = source.Select(t => t.Item2);

            return x.Covariance(y) / (x.StandardDeviationP() * y.StandardDeviationP());
        }
        
        /// <summary>
        ///     Computes the Pearson of a sequence of nullable double values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The first sequence of double values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of double values to calculate the Pearson of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Pearson of the sequence of values.</returns>
        public static double? Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, double?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

             if (other == null)
                throw new ArgumentNullException("other");

           if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Pearson(other.Select(selector));
        }

        /// <summary>
        ///     Computes the Pearson of a sequence of nullable double values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The first sequence of double values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of double values to calculate the Pearson of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Pearson of the sequence of values.</returns>
        public static double Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, double> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (other == null)
                throw new ArgumentNullException("other");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Pearson(other.Select(selector));
        }
     }
}