using DapperMapper;
using Edgy.DapperMapper.Test.Entities;

namespace Edgy.DapperMapper.Test;

[TestClass]
public class PropertyToColumnMapperTests
{
    [TestMethod]
    public void Map_WithMappedProperties_SetsTypeMap()
    {
        // Act
        PropertyToColumnMapper.Map<TestEntity>();

        // Assert
        var typeMap = Dapper.SqlMapper.GetTypeMap(typeof(TestEntity));
        typeMap.AssertMemberMap("TEST_ENTITY_ID", "Id");
        typeMap.AssertMemberMap("TEST_ENTITY_NAME", "Name");
    }

    [TestMethod]
    public void MapAll_WithMappedProperties_SetsTypeMap()
    {
        // Act
        PropertyToColumnMapper.MapAll();

        // Assert
        var firstEntityTypeMap = Dapper.SqlMapper.GetTypeMap(typeof(FirstEntityWithDapperMapAttribute));
        firstEntityTypeMap.AssertMemberMap("ENTITY_ID", "Id");
        firstEntityTypeMap.AssertMemberMap("ENTITY_NAME", "Name");

        var secondEntityTypeMap = Dapper.SqlMapper.GetTypeMap(typeof(SecondEntityWithDapperMapAttribute));
        secondEntityTypeMap.AssertMemberMap("ENTITY_ID", "Id");
        secondEntityTypeMap.AssertMemberMap("ENTITY_DATE_TIME", "DateTime");
    }
}