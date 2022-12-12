using Microsoft.AspNetCore.Mvc.RazorPages;

public class FirstPageModels:PageModel
{
    public string title {set ; get;} = "Su dung function duoc truy cap qua this.title";

    public string Welcom(string name)
    {
        return $"Chào mừng {name} đến với Website, dòng này là sử dụng hàm";
    }

    // Khi ta tạo các phương thức OnGet(), OnGetAbc(),... hoặc OnPost(), OnPostAbc()
    // Thì những phương thức này được gọi là Handler
    // Trong đó phương thức OnGet() tự động được gọi khi truy vấn đến trang FirstPage
    public void OnGet()
    {
        Console.WriteLine("Truy van Get");
        ViewData["mydata"] = "Truyền dữ liệu cho ViewData";
    }
    // Để truy vấn phương thức OnGetXYZ thì: yêu cầu là truy vấn Get, \Url?handler=XYZ   
    public void OnGetXYZ()
    {
        Console.WriteLine("Truy van OnGetXYZ");
        ViewData["mydata"] = "Truy van OnGetXYZ";
    }
}