using System.ComponentModel.DataAnnotations.Schema;

namespace Edgy.DapperMapper.Test.Entities;

[TableAttribute("TABLE_NAME_NOT_RELEVANT_ONLY_ATTRIBUTE")]
public class FirstEntityWithDapperMapperAttribute
{
    [Column("ENTITY_ID")]
    public int Id { get; set; }

    [Column("ENTITY_NAME")]
    public string Name { get; set; } = string.Empty;
}
