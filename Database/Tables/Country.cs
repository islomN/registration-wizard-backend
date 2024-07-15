using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Tables;

[Table("Countries")]
public record Country(
    [property: Column("ID")]
    int ID,
    [property: Column("Name")]
    [property: Required]
    [property: MinLength(1)]
    string Name);