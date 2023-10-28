using Dapper;
using Edgy.DapperMapper;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperMapper;

public static class PropertyToColumnMapper
{
    /// <summary>
    /// Map properties to column names for the given type <see cref="{T}"/>.
    /// </summary>
    public static void Map<T>()
    {
        Map(typeof(T));
    }

    /// <summary>
    /// Map properties to column names for all types in all assemblies of the application.
    /// </summary>
    public static void MapAll()
    {
        var types = GetTypesWithDapperMapAttribute();
        foreach (var type in types)
        {
            Map(type);
        }
    }

    private static void Map(Type type)
    {
        var customPropertyTypeMap = new CustomPropertyTypeMap(type, (type, columnName) =>
        {
            var properties = type.GetProperties();

            var propertyInfo = properties.FirstOrDefault(pi =>
                pi.GetCustomAttributes(false)
                    .OfType<ColumnAttribute>()
                    .Any(attr => attr.Name == columnName));

            return propertyInfo;
        });

        Dapper.SqlMapper.SetTypeMap(type, customPropertyTypeMap);
    }
    private static IEnumerable<Type> GetTypesWithDapperMapAttribute()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(DapperMapAttribute), true).Length > 0)
                {
                    yield return type;
                }
            }
        }
    }
}
