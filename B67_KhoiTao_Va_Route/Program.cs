namespace B67_KhoiTao_Va_Route;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Đăng ký những dịch vụ liên quan đến Razor Page(thiết lập mặc định là trang Page)
        //builder.Services.AddRazorPages();

        // Nếu ta muốn thay đổi trang không phải tên Page nữa thì thực hiện như sau:
        builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
        {
            options.RootDirectory = "/Pages";

            // Ta có thể thiết lập lại tên trang truy cập trên web Cách 1
            // options.Conventions.AddPageRoute("/FirstPage", "/trangdautien");
            // options.Conventions.AddPageRoute("/SecondPage", "trangthu2");
            // options.Conventions.AddPageRoute("/ThirdPage", "trangthu3");

        });

        // Thiết lập tất cả địa chỉ truy cập URL là chữ in thường
        builder.Services.Configure<RouteOptions>(routeOptions => {
            routeOptions.LowercaseUrls = true;
        });

        var app = builder.Build();

        app.UseRouting();
        app.UseEndpoints((IEndpointRouteBuilder endpoint) =>
        {

            // Dichvu/Dichvu1
            endpoint.MapRazorPages();
        });

        app.MapGet("/", () => "Hello World!");
        app.Run();
    }
}
/*
    - Khi ta gọi MapRazorPages thì nó sử dụng các trang có cấu hình Pages như là một địa chỉ truy cập
    - VD Ta có file là FirstPage.cshtml thì khi ta truy cập trên web địa chỉ FirstPage nó sẽ dẫn tới trang đó
    - Ta có thể truy cập các trang thông qua tên file
    - Nếu trong thư mục Pages có thư mục khác thì sẽ truy cập lần lượt theo cấp độ: /Dichvu/Dichvu1, Nếu có trang index.cshtml thì mặc định nó sẽ vào trang này
    - Khai báo file .cshtml 
        + Đầu trang phải có @Page
        + @biến, @(biểu thức), @phương_thức, @{ Khối lệnh Code C# hoặc html đều được }
    - Tiến hành đăng ký dịch vụ, Sử dụng Endpoint để truy cập đến trang

    - Sử dụng Tag Helper --> dùng để phát sinh code html
        + @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelper
        + Có thể phát sinh ra thẻ liên kết đến trang khác

    - Thường các trang Razor Page nó được lưu trữ trong thư mục Areas

    - Phương thức ViewData dùng để truyền dữ liệu giữa các phương thức được sử dụng trong .cshtml, được lưu trữ thông qua Key
    - ViewData["mydata"]

    - Thư mục Share dùng để chứa những file cshtml để truyền đến cho CLient
    - Khi đặt tên file trong thư mục Share ta thêm _ để Endpoint nó không truy cập đến 

    - File ViewStart.cshtml có nhiệm vụ là sẽ tự động Add các trang cùng sử dụng chung một _MyLayout, Khi trang FirstPage mở ra
         thì nó tự động thêm file _ViewStart vào phần đầu trước 
    - file _ViewImports.cshtml cũng tương tự như file _ViewStart.cshtml, Nó dùng để thêm các 
        + @using
        + @TagHeper
        + inject
        --> Giúp ta khỏi tốn công đi thêm từng file chi tiết
*/
