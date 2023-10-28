using Dapper;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperMapper;

public static class PropertyToColumnMapper
{
    public static void Map<T>()
    {
        var customPropertyTypeMap = new CustomPropertyTypeMap(typeof(T), (type, columnName) =>
        {
            var properties = type.GetProperties();

            var propertyInfo = properties.FirstOrDefault(pi =>
                pi.GetCustomAttributes(false)
                    .OfType<ColumnAttribute>()
                    .Any(attr => attr.Name == columnName));

            return propertyInfo;

        });

        Dapper.SqlMapper.SetTypeMap(typeof(T), customPropertyTypeMap);
    }
}
