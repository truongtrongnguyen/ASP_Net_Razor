using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ContactRequestModel : PageModel
{
    [BindProperty]
    public UserContact userContact{get; set;}
    // inject một đối tượng Ilogger của hệ thống vào để sau này có thể sử dụng lại
    private readonly ILogger<ContactRequestModel> _logger;
    public ContactRequestModel(ILogger<ContactRequestModel> logger)
    {
        _logger = logger;
        _logger.LogInformation("Init UserID...");   // Khởi tạo và xuất ra màn hình trên vs code
        //Console.WriteLine("Init contact ...");
    }

    public void OnPost()
    {
        Console.WriteLine(this.userContact.Email);
        Console.WriteLine(this.userContact.UserID);
        Console.WriteLine(this.userContact.UserName);
    }

     public double Tinhtong(double a, double b)
    {
        return a + b ;
    }
}

/*
    Hoặc tạo một PageRazor thông qua lệnh: 
    -n: tên file
    -o: thư mục lưu trữ
    -na: thuộc namespace nào

    dotnet new page -n ProductPage -o Pages -na B74_OnTap_PageModel.Pages
*/