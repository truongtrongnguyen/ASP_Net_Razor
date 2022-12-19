var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<ProductListService>();

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
    Partial View: 
        - Là cách thức mà ta chia nhỏ các file cshtml thành nhiều file nhỏ html khác nhau
        - Các file cshtml này nó không có chỉ thị @page ngay đầu trang
        - Chia nhỏ các file xong sau đó gộp chúng lại
        - Sử dụng lại các thành phần, tránh trùng lặp code

    Component: Nó tương tự như Partial nhưng nó có thêm sử dụng dịch vụ DI inject để inject những dịch vụ của 
    hệ thống vào Component, sau đó Component sử dụng các dịch vụ đó, Nó tương đương như là một trang Min Razor Page nhỏ
*/
