using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class CustomerInfo
{
    [Display(Name= "Tên khách")]
    [Required(ErrorMessage ="Phải nhập {0}")]
    [StringLength(20, MinimumLength =3, ErrorMessage="{0} phải dài từ {2} đến {1} ký tự")]
    [ModelBinder(BinderType =typeof(UserNameBinding))]
    public string CustomerName {get;set;}

    [DisplayName("Địa chỉ Email")]
    [Required(ErrorMessage ="Phải nhập {0}")]
    [EmailAddress(ErrorMessage ="{0} không phù hợp")]
    public string Email {get; set;}

    [DisplayName("Năm sinh")]
    [Required(ErrorMessage ="Phải nhập {0}")]
    [Range(1970, 2000, ErrorMessage ="{0} phải trong phạm vi {1} - {2}")]
    [SoChan]
    public int? YearOfBirth {get; set;}
}