using Dapper;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edgy.DapperMapper;

public static class DapperCustomPropertyTypeMapper
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
        var types = GetTypesWithTableAttribute();
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

            // PropertyInfo will be null for columns that are returned by a query for which the entity has no matching
            // property/ColumnAttribute combination. A null return value for propertyInfo does not produce any errors.

            return propertyInfo;
        });

        Dapper.SqlMapper.SetTypeMap(type, customPropertyTypeMap);
    }

    private static IEnumerable<Type> GetTypesWithTableAttribute()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(TableAttribute), true).Length > 0)
                {
                    yield return type;
                }
            }
        }
    }
}
