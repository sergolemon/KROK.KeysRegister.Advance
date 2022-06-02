using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class ProfileForAssembly : Profile
    {
        public ProfileForAssembly(Assembly assembly)
        {
            ApplyMappingsFromAssembly(assembly);
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            IEnumerable<Type> types = assembly.GetTypes().Where(type => type.IsClass && type.IsAssignableTo(typeof(IMap)));

            foreach(Type type in types)
            {
                object? instance = Activator.CreateInstance(type);
                MethodInfo? methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
