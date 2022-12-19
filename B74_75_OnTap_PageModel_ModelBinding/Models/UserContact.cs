using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class UserContact
{
    //[BindProperty(SupportsGet =true)]       // /contact.html?UserID=2&UserName=abc
    [BindProperty]
    [DisplayName("ID của bạn: ")]
    [Range(10, 100, ErrorMessage="Nhap sai")]
    public int UserID{get; set;}

    [BindProperty]
    [DisplayName("Email của bạn: ")]
    [EmailAddress(ErrorMessage ="Email sai định dạng")]
    public string Email {get; set;}

    //[BindProperty(SupportsGet =true)]
    [BindProperty]
    [DisplayName("Tên của bạn: ")]
    public string UserName {get; set;}

}