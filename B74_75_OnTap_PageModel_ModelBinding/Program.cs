var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
/*
    - Model Biding: Liên kết dữ liệu
    - Dữ liệu gởi đến gồm (Key, Value)
    - Nguồn dữ liệu nó đến từ: 
        + Form html(post)           HtmlRequest.Form["key"]
        + Query (form html - get)   HtmlRequest.Query["key"]
        + Header                    HtmlRequest.Header["key"]
        + Route Data                HtmlRequest.RouteValues["key"]
        + Upload
        + body
    - Đọc dữ liệu từ: HttpRequest (Controller, PageModel, View)


    - Cơ chế Binding: Những dữ liệu được gởi đến sẽ được tự động đọc và tự động chuyển đổi thanh kiểu dữ liệu mong muốn
    - Nó sử dụng Attribute: Parameter Binding, Property Binding
    - Parameter Binding
        Nếu các phương thức OnGet hoặc là Action nó có tham số là id thì khi sử dụng Binding nó sẽ tìm tất cả các nguồn dữ liệu 
            gởi đến xem có dữ liệu nào có key là id, nếu có nó sẽ tự động đọc và chuyển đổi thành kiểu dữ liệu tương ứng 
        Nếu trong truy vấn là /product/2?id=3 thì nó sẽ ưu tiên đọc 2(RouteValues) trước và nó sẽ không đọc ?id=3(Query)
        Còn nếu không có RouteValues thì nó sẽ đọc Query
        Hoặc đọc từ nguồn dữ liệu cụ thể
        [FromQuery]
        [FromRoute]
        [FromForm]
        [FromHeader]
        Hoặc có thể thiết lập Key tìm kiếm là: OnGet([FromQuery(Name ="sanpham")] int? id)
        Hoặc ngoài ra ta có thể truyền vào là một Product để tìm theo Product đó
    -Property Binding   (VD bên trang contact.html)
        Nó sẽ tự động tìm kiếm theo tên của Property có khai báo Attribute là: [BinProperty]
        Nó không được Binding ở phương thức Get mà là phương thức Post --> Submit dữ liệu bằng form và post nó lên
        Hoặc là sử dụng lệnh hỗ trợ: [BindingProperty(SupportGet=true)]
*/

