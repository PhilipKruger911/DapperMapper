using System.ComponentModel.DataAnnotations.Schema;

namespace Edgy.DapperMapper.Test.Entities;

[DapperMap]
public class FirstEntityWithDapperMapAttribute
{
    [Column("ENTITY_ID")]
    public int Id { get; set; }

    [Column("ENTITY_NAME")]
    public string Name { get; set; } = string.Empty;
}
