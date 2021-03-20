using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Arya.Core.Application.AutoMapper.Extensions
{
    public static class MapperExtension
    {
        public static TDestination Map<TDestination>(this object source, IHttpContextAccessor _httpsAccessor)
        {
            var mapper = _httpsAccessor.HttpContext.RequestServices.GetService<IMapper>();
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            return mapper.Map<TDestination>(source);
        }
    }
}
