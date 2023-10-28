using System.ComponentModel.DataAnnotations.Schema;

namespace Edgy.DapperMapper.Test.Entities;

[DapperMap]
public class SecondEntityWithDapperMapAttribute
{
    [Column("ENTITY_ID")]
    public int Id { get; set; }

    [Column("ENTITY_DATE_TIME")]
    public DateTime DateTime { get; set; }
}
