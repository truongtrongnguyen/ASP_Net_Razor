using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace razprweb.models;

public class Article
{
    [Key]
    [Display(Name ="ID")]
    [Required(ErrorMessage ="Phải nhập {0}")]
    public int Id {get; set;}

    [Display(Name ="Tiêu đề")]
    [Required(ErrorMessage ="Phải nhập {0}")]
    [StringLength(100, MinimumLength =2, ErrorMessage ="{0} phải từ {2} đến {1} ký tự")]
    public string Title {get; set;}

    [Display(Name ="Ngày tạo")]
    [Required(ErrorMessage ="Phải nhập {0}")]
    [DataType(DataType.Date)]
    public DateTime Created {get; set;}

    [Display(Name ="Nội dung")]
    [Column(TypeName="text")]
    public string Content {get; set;}
}