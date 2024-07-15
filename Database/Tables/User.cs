using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Tables;

[Table("Users")]
public record User(
    [property: Column("ID")]
    int ID,
    [property: Column("Login")]
    [property: Required]
    string Login,
    [property: Column("PasswordHash")]
    [property: Required]
    string PasswordHash,
    [property: Column("ProvinceID")]
    int ProvinceID)
{
    [ForeignKey("ProvinceID")]
    public Province Province { get; set; }
};