using System;
using System.Linq;
using System.Linq.Expressions;

namespace PianoMelody.Web.Extensions
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Get random elements while process query
        /// </summary>
        /// <typeparam name="T">The type of the objects</typeparam>
        /// <param name="query">this Queryable</param>
        /// <param name="e">lambda expression</param>
        /// <param name="number">The count of the required random elements</param>
        /// <returns>this Queryable</returns>
        public static IQueryable<T> RandomElements<T>(this IQueryable<T> query, Expression<Func<T, bool>> e, int number = 1)
        {
            var rand = new Random();
            query = query.Where(e);

            return query.Skip(rand.Next(query.Count()))
                        .Take(number);
        }
    }
}