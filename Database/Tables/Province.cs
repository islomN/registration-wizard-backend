using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Tables;

[Table("Provinces")]
public record Province(
    [property: Column("ID")]
    int ID,
    [property: Column("Name")]
    [property: Required]
    [property: MinLength(1)]
    string Name,
    [property: Column("CountryID")]
    int CountryID)
{
    [ForeignKey("CountryID")]
    public Country Country { get; set; }
};