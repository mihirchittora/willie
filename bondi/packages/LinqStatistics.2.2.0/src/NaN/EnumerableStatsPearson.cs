﻿//
// THIS FILE IS AUTOGENERATED - DO NOT EDIT
// In order to make changes make sure to edit the t4 template file (*.tt)
//

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics.NaN
{
    public static partial class EnumerableStats
    {
    	
        /// <summary>
        /// Computes the Pearson of two sequences of nullable int values.
        /// </summary>
        /// <param name="source">The first sequence of nullable int values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of nullable int values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static double? PearsonNaN(this IEnumerable<int?> source, IEnumerable<int?> other)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.PearsonNaN(other.AllValues());

            return null;
        }

        /// <summary>
        /// Computes the Pearson of two sequences of int values.
        /// </summary>
        /// <param name="source">The first sequence of int values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of int values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static double PearsonNaN(this IEnumerable<int> source, IEnumerable<int> other)
        {
            return source.CovarianceNaN(other) / (source.StandardDeviationPNaN() * other.StandardDeviationPNaN());
        }

        /// <summary>
        /// Computes the Pearson of the Item values of a sequence of Tuple{int, int} values.
        /// </summary>
        /// <param name="source">The type of the Tuple's Items.</param>
        /// <returns>The Pearson value.</returns>
        public static double PearsonNaN(this IEnumerable<Tuple<int, int>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var x = source.Select(t => t.Item1);
            var y = source.Select(t => t.Item2);

            return x.CovarianceNaN(y) / (x.StandardDeviationPNaN() * y.StandardDeviationPNaN());
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
        public static double? PearsonNaN<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, int?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

             if (other == null)
                throw new ArgumentNullException("other");

           if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).PearsonNaN(other.Select(selector));
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
        public static double PearsonNaN<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, int> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (other == null)
                throw new ArgumentNullException("other");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).PearsonNaN(other.Select(selector));
        }
 	
        /// <summary>
        /// Computes the Pearson of two sequences of nullable long values.
        /// </summary>
        /// <param name="source">The first sequence of nullable long values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of nullable long values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static double? PearsonNaN(this IEnumerable<long?> source, IEnumerable<long?> other)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.PearsonNaN(other.AllValues());

            return null;
        }

        /// <summary>
        /// Computes the Pearson of two sequences of long values.
        /// </summary>
        /// <param name="source">The first sequence of long values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of long values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static double PearsonNaN(this IEnumerable<long> source, IEnumerable<long> other)
        {
            return source.CovarianceNaN(other) / (source.StandardDeviationPNaN() * other.StandardDeviationPNaN());
        }

        /// <summary>
        /// Computes the Pearson of the Item values of a sequence of Tuple{long, long} values.
        /// </summary>
        /// <param name="source">The type of the Tuple's Items.</param>
        /// <returns>The Pearson value.</returns>
        public static double PearsonNaN(this IEnumerable<Tuple<long, long>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var x = source.Select(t => t.Item1);
            var y = source.Select(t => t.Item2);

            return x.CovarianceNaN(y) / (x.StandardDeviationPNaN() * y.StandardDeviationPNaN());
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
        public static double? PearsonNaN<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, long?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

             if (other == null)
                throw new ArgumentNullException("other");

           if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).PearsonNaN(other.Select(selector));
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
        public static double PearsonNaN<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, long> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (other == null)
                throw new ArgumentNullException("other");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).PearsonNaN(other.Select(selector));
        }
 	
        /// <summary>
        /// Computes the Pearson of two sequences of nullable float values.
        /// </summary>
        /// <param name="source">The first sequence of nullable float values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of nullable float values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static float? PearsonNaN(this IEnumerable<float?> source, IEnumerable<float?> other)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.PearsonNaN(other.AllValues());

            return null;
        }

        /// <summary>
        /// Computes the Pearson of two sequences of float values.
        /// </summary>
        /// <param name="source">The first sequence of float values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of float values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static float PearsonNaN(this IEnumerable<float> source, IEnumerable<float> other)
        {
            return source.CovarianceNaN(other) / (source.StandardDeviationPNaN() * other.StandardDeviationPNaN());
        }

        /// <summary>
        /// Computes the Pearson of the Item values of a sequence of Tuple{float, float} values.
        /// </summary>
        /// <param name="source">The type of the Tuple's Items.</param>
        /// <returns>The Pearson value.</returns>
        public static float PearsonNaN(this IEnumerable<Tuple<float, float>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var x = source.Select(t => t.Item1);
            var y = source.Select(t => t.Item2);

            return x.CovarianceNaN(y) / (x.StandardDeviationPNaN() * y.StandardDeviationPNaN());
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
        public static float? PearsonNaN<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, float?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

             if (other == null)
                throw new ArgumentNullException("other");

           if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).PearsonNaN(other.Select(selector));
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
        public static float PearsonNaN<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, float> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (other == null)
                throw new ArgumentNullException("other");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).PearsonNaN(other.Select(selector));
        }
 	
        /// <summary>
        /// Computes the Pearson of two sequences of nullable double values.
        /// </summary>
        /// <param name="source">The first sequence of nullable double values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of nullable double values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static double? PearsonNaN(this IEnumerable<double?> source, IEnumerable<double?> other)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.PearsonNaN(other.AllValues());

            return null;
        }

        /// <summary>
        /// Computes the Pearson of two sequences of double values.
        /// </summary>
        /// <param name="source">The first sequence of double values to calculate the Pearson of.</param>
        /// <param name="other">The second sequence of double values to calculate the Pearson of.</param>
        /// <returns>The Pearson value of two sequences.</returns>
        public static double PearsonNaN(this IEnumerable<double> source, IEnumerable<double> other)
        {
            return source.CovarianceNaN(other) / (source.StandardDeviationPNaN() * other.StandardDeviationPNaN());
        }

        /// <summary>
        /// Computes the Pearson of the Item values of a sequence of Tuple{double, double} values.
        /// </summary>
        /// <param name="source">The type of the Tuple's Items.</param>
        /// <returns>The Pearson value.</returns>
        public static double PearsonNaN(this IEnumerable<Tuple<double, double>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var x = source.Select(t => t.Item1);
            var y = source.Select(t => t.Item2);

            return x.CovarianceNaN(y) / (x.StandardDeviationPNaN() * y.StandardDeviationPNaN());
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
        public static double? PearsonNaN<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, double?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

             if (other == null)
                throw new ArgumentNullException("other");

           if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).PearsonNaN(other.Select(selector));
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
        public static double PearsonNaN<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, double> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (other == null)
                throw new ArgumentNullException("other");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).PearsonNaN(other.Select(selector));
        }
     }
}