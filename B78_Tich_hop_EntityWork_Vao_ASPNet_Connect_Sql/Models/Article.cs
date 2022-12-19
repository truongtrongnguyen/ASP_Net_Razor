using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace razorweb.modles;

public class Article
{
    [Key]
    public int id {get; set;}
    [Required]
    [Column(TypeName="nvarchar")]
    [StringLength(255)]
    public string? Title {get; set;}
    [Required]
    [DataType(DataType.Date)]
    public DateTime Created {get; set;}
    [Column(TypeName ="ntext")]
    public string? Content {get; set;}
}