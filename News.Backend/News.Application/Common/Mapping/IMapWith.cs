using System.Reflection;
using AutoMapper;

namespace News.Application.Common.Mapping
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }

    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile() : this(Assembly.GetExecutingAssembly()) { }

        public AssemblyMappingProfile(Assembly assembly) =>
        ApplyMappingsFromAssembly(assembly);

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            List<Type> types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(type => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach (Type type in types)
            {
                object? instance = Activator.CreateInstance(type);
                MethodInfo? method = type.GetMethod("Mapping");
                method?.Invoke(instance, new object[] { this });
            }
        }
    }
}