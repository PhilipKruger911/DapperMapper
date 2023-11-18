using Edgy.DapperMapper.Test.Entities;

namespace Edgy.DapperMapper.Test;

[TestClass]
public class DapperCustomPropertyTypeMapperTests
{
    [TestMethod]
    public void Map_EntityWithPropertiesThatHaveColumnAttribute_SetsTypeMap()
    {
        // Act
        DapperCustomPropertyTypeMapper.Map<TestEntity>();

        // Assert
        var typeMap = Dapper.SqlMapper.GetTypeMap(typeof(TestEntity));
        typeMap.AssertMemberMap("TEST_ENTITY_ID", "Id");
        typeMap.AssertMemberMap("TEST_ENTITY_NAME", "Name");
    }

    [TestMethod]
    public void MapAll_EntitiesWithTableAttributeAndPropertiesThatHaveColumnAttribute_SetsTypeMaps()
    {
        // Act
        DapperCustomPropertyTypeMapper.MapAll();

        // Assert
        var firstEntityTypeMap = Dapper.SqlMapper.GetTypeMap(typeof(FirstEntityWithDapperMapperAttribute));
        firstEntityTypeMap.AssertMemberMap("ENTITY_ID", "Id");
        firstEntityTypeMap.AssertMemberMap("ENTITY_NAME", "Name");

        var secondEntityTypeMap = Dapper.SqlMapper.GetTypeMap(typeof(SecondEntityWithDapperMapperAttribute));
        secondEntityTypeMap.AssertMemberMap("ENTITY_ID", "Id");
        secondEntityTypeMap.AssertMemberMap("ENTITY_DATE_TIME", "DateTime");
    }
}