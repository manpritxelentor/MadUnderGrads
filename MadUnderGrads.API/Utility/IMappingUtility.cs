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
        IQueryable<TM> Project<T, TM>(IQueryable<T> source)
             where T : class
            where TM : class;

        TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class;

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
            where TSource : class
            where TDestination : class;
    }

    public class MappingUtility : IMappingUtility
    {
        public TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class
        {
            return Mapper.Map<TSource, TDestination>(source);
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