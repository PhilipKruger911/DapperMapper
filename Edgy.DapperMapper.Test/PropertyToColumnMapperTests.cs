using DapperMapper;
using Edgy.DapperMapper.Test.Entities;

namespace Edgy.DapperMapper.Test
{
    [TestClass]
    public class PropertyToColumnMapperTests
    {
        [TestMethod]
        public void Map_WithTwoProperties_SetsTypeMap()
        {
            // Act
            PropertyToColumnMapper.Map<TestEntity>();

            // Assert
            var typeMap = Dapper.SqlMapper.GetTypeMap(typeof(TestEntity));
            typeMap.AssertMemberMap("TEST_ENTITY_ID", "Id");
            typeMap.AssertMemberMap("TEST_ENTITY_NAME", "Name");
        }
    }
}