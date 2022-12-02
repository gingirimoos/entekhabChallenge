using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => !a.IsDynamic)
            .SelectMany(a => a.GetExportedTypes());

            ApplyMappingsFromAssembly(types);
        }

        private void ApplyMappingsFromAssembly(IEnumerable<Type> types)
        {

            var mappertypes = (from t in types
                               where t.GetInterfaces().Any(i => i.IsGenericType
                               && i.GetGenericTypeDefinition() == typeof(IMapFrom<,>))
                               && !t.IsAbstract
                               select t).ToList();

            foreach (var type in mappertypes)
            {
                try
                {
                    var instance = Activator.CreateInstance(type);

                    var methodInfo = type.GetMethod("Mapping")
                        ?? type.GetInterface("IMapFrom`2").GetMethod("Mapping");

                    methodInfo?.Invoke(instance, new object[] { this });
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}