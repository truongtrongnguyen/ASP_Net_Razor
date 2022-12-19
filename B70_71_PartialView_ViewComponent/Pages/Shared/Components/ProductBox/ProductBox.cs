using Microsoft.AspNetCore.Mvc;

namespace XTL;

[ViewComponent]
public class ProductBox : ViewComponent
{
    // Danh sách Product được Inject từ một thư mục khác đưa vào thông qua phương thức đăng ký dịch vụ
    private ProductListService productsservice {get; set;}
    public ProductBox(ProductListService products)
    {
        productsservice = products;
    }

    //  LƯU Ý TÊN FILE : Components
    // Để class này được coi là một Component thì nó cần có Invoke hoặc InvokeAsync --> Nó phải trả về kiểu string hoặc 
    // kiểu IViewComponentResult, không được trả về kiểu khác   
    // Nếu phương thức có tham số (Invoke(object obj)) thì khi gọi Component ta cũng cần truyền tham số đó vào

    // Ngoài ra ta cần thiết lập lớp này là một Attribute [ViewComponent]
    // Hoặc khai báo tên lớp có hậu tố là ViewComponent VD: ProductBoxViewComponent
    // Hoặc khai báo lớp đó có kế thừa từ ViewComponent

    // public IViewComponentResult Invoke()
    // {
    //     // Khi đã thiết lập kiểu trả về là IViewComponent thì ta phải trả thông qua View
    //     // Mặc định nó sẽ thi hành file Default.cshtml hoặc có thể truyền vào tên file
    //     // Hoặc có thể thiết lập Model cho nó là một kiểu chuỗi và phải truyền tham số vào
    //     return View<string>("Xin chào các bạn");  
    // }

    // Truyền tham số cho View là một List Product
    public IViewComponentResult Invoke(bool sapxep = true)
    {
        // var products = new List<Product>() {
        //      new Product() { Name = "IPhone 14", Desciptions = "Điện thoại IPhone của Apple", Price = 1000 },
        //     new Product() { Name = "SamSung", Desciptions = "Điện thoại SamSung của SamSung", Price = 800 },
        //     new Product() { Name = "Nokia", Desciptions = "Điện thoại Nokia của Nokia", Price = 500 },
        //     new Product() { Name = "IPhone 14 Promax", Desciptions = "Điện thoại IPhone của Apple", Price = 2000 },
        //     new Product() { Name = "Nokia", Desciptions = "Điện thoại IPhone của Apple", Price = 1200 }
        // };       ĐÓNG LẠI DO ĐẪ CÓ DANH SÁCH PRODUCT ĐƯỢC TRUYỀN TỪ MỘT FILE KHÁC VÀO

        List<Product> _products = null;
        if(sapxep)
        {
            _products = productsservice.products.OrderBy(p => p.Price).ToList();
        }
        else{
            _products = productsservice.products.OrderByDescending(p => p.Price).ToList();
        }
        return View<List<Product>>(_products);
    }
}