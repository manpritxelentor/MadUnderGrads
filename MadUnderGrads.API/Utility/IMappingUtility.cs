using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace MadUnderGrads.API.Utility
{
    public interface IMappingUtility
    {
        /// <summary>
        /// Projects the query
        /// </summary>
        /// <typeparam name="T">Source type</typeparam>
        /// <typeparam name="TM">Destination type</typeparam>
        /// <param name="source">Source query</param>
        /// <returns></returns>
        IQueryable<TM> Project<T, TM>(IQueryable<T> source)
             where T : class
            where TM : class;

        /// <summary>
        /// Map object
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="source">Source object</param>
        /// <returns></returns>
        TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class;

        /// <summary>
        /// Map object in provided object
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <returns></returns>
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
            where TSource : class
            where TDestination : class;

        object Map(object source, Type sourceType, Type destinationType);
    }

    public class MappingUtility : IMappingUtility
    {
        public TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
            where TSource : class
            where TDestination : class
        {
            return Mapper.Map(source, destination);
        }

        public IQueryable<TM> Project<T,TM>(IQueryable<T> source)
            where T: class
            where TM : class
        {
            return source.ProjectTo<TM>();
        }
    }
}