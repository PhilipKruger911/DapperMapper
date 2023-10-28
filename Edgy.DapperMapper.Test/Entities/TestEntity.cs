using System.ComponentModel.DataAnnotations.Schema;

namespace Edgy.DapperMapper.Test.Entities;

public class TestEntity
{
    [Column("TEST_ENTITY_ID")]
    public int Id { get; set; }

    [Column("TEST_ENTITY_NAME")]
    public string Name { get; set; } = string.Empty;
}
