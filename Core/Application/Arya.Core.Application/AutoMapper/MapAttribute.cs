using System;

namespace Arya.Core.Application.AutoMapper
{
    public class MapAttribute : Attribute
    {
        public Type[] MapTo { get; set; }
        public Type[] MapFrom { get; set; }
    }
}
