using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Arya.Core.Application.AutoMapper
{
    public class AutoMapperDetector
    {
        public static void Map(IMapperConfigurationExpression config)
        {
            var viewModelTypes =
                from t in Assembly.LoadFrom("Arya.Core.Application.ViewModel").GetTypes()
                where typeof(IAutoMapMarker).IsAssignableFrom(t)
                select t;


            foreach (var type in viewModelTypes)
            {
                var attribute = type.GetCustomAttribute(typeof(MapAttribute), false);
                var mapToProperty = attribute.GetType().GetProperty("MapTo");
                var mapFromProperty = attribute.GetType().GetProperty("MapFrom");

                // get properties value
                var mapTo = (Array)mapToProperty?.GetValue(attribute, null);
                var mapFrom = (Array)mapFromProperty?.GetValue(attribute, null);

                if (mapTo != null)
                    foreach (var mapper in mapTo)
                    {
                        config.CreateMap(type, (Type)mapper);
                    }

                if (mapFrom != null)
                    foreach (var mapper in mapFrom)
                    {
                        config.CreateMap((Type)mapper, type);
                    }
            }
        }
    }
}
