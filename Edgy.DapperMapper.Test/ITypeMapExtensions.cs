using static Dapper.SqlMapper;

namespace Edgy.DapperMapper.Test;

public static class ITypeMapExtensions
{
    public static void AssertMemberMap(this ITypeMap typeMap, string columnName, string propertyName)
    {
        var idMember = typeMap.GetMember(columnName);
        Assert.IsNotNull(idMember);
        Assert.IsNotNull(idMember.Property);
        Assert.AreEqual(propertyName, idMember.Property.Name);

    }
}
