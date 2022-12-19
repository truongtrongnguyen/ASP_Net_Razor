using Microsoft.EntityFrameworkCore;
using razorweb.modles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Đọc đối tượng của dịch vị thông qua Services
builder.Services.AddDbContext<MyBlogContext>(options => {
    string connectString = builder.Configuration.GetConnectionString("MyBlogContext");
    options.UseSqlServer(connectString);
});

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
    Để làm việc với EF, hãy thêm các công cụ vào dotnet cũng như tích hợp các Package cần thiết, thực hiện các lệnh sau:
        dotnet tool install --global dotnet-ef
        dotnet tool install --global dotnet-aspnet-codegenerator
        dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
        dotnet add package Microsoft.EntityFrameworkCore.Design
        dotnet add package Microsoft.EntityFrameworkCore.SqlServer

        - Xoá Database: dotnet ef database drop -f
*/
