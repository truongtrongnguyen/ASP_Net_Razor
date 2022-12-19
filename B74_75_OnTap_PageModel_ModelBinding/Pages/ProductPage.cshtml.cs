using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace B74_OnTap_PageModel.Pages
{
    public class ProductPageModel : PageModel
    {

        public ProductService _productService;
        private readonly ILogger<ProductPageModel> _logger;
        public ProductPageModel(ILogger<ProductPageModel> logger, ProductService productService)
        {
            _logger = logger;   // logger để xuất ra màn hình
             _productService = productService;
        }

        public Product product{get; set;}

        // OnGet, OnPost, OnGetAbc,.. --> thuộc HttpRequest ---> Có kiểu trả về là void hoặc IActionResult
        // public void OnGet()
        // {
        //     if(Request.RouteValues["id"] != null)
        //     {
        //         int id = int.Parse(Request.RouteValues["id"].ToString());
        //         ViewData["title"] = $"Sản phẩm (id = {id})";
        //     }
        //     else
        //     {
        //         ViewData["title"] = "Danh sách sản phẩm";
        //     }   
        // }
        // Cách 2
        public void OnGet(int? id,[Bind("id", "Name")] Product product)     // product/?id=10&Name=IPhone14Pro
        {
            Console.WriteLine("ID: "+ product.id);
            Console.WriteLine("Name: "+product.Name);

            /*  Ví dụ đọc dữ liệu từ URL

            // var data = this.Request.RouteValues["id"];        /product/2
                var data = this.Request.RouteValues["id"];
                if(id != null)
                {
                    Console.WriteLine(data.ToString());
                }

            // var data = this.Request.Query["id"];               product/?id=2   
            --> Nó trả về kiểu string nên ta không cần Convert nó mà chỉ kiểm tra khác null: string.IsNullOrEmpty(data)
                var data = this.Request.Query["id"];
                if(!String.IsNullOrEmpty(data))
                {
                    Console.WriteLine(data);
                    int i = Int16.Parse(data.ToString());
                }
            */
          
            // var data = this.Request.Header["user-agent"];        // Tương tự Query nhưng truy vấn là các tên trong Header

            // var data = this.Request.Form["id"];
            
            
            var data = this.Request.Query["id"];
            if(!String.IsNullOrEmpty(data))
            {
                Console.WriteLine(data);
                int i = Int16.Parse(data.ToString());
            }


            if(id != null)
            {
                 ViewData["title"] = $"Sản phẩm (ID = {id.Value})";
                 product = _productService.Find(id.Value);
            }
            else
            {
                ViewData["title"] = "Danh sách sản phẩm";
            }   
        }

        // product/{id:int?}handler=lastproduct  --> Khi truy cập địa chỉ handler là lastproduct thì nó sẽ thi hành function bên dưới
        public IActionResult OnGetLastProduct()
        {
            ViewData["title"] = "Sản phẩm cuối";
            product = _productService.AllProduct().LastOrDefault();
            if(product != null)
            {
                return Page();
            }
            else
            {
                return this.Content("Không tìm thấy sản phẩm");
                // Có thể trả về các status code
            }
        }

        public IActionResult OnGetRemove()
        {
            _productService.AllProduct().Clear();
            return RedirectToPage("ProductPage");   // Sau khi xóa xong cho nó chuyển hướng đến trang chính
        }

        public void OnGetAddProduct()
        {
            _productService.LoadProducts();
            ViewData["title"] = "Thêm sản phẩm thành công";
        }

        public IActionResult OnPostDelete(int? id)
        {
            if(id != null)
            {
                product = _productService.Find(id.Value);
                if(product != null)
                {
                    _productService.AllProduct().Remove(product);
                }
            }
            return RedirectToPage("ProductPage", new {id = String.Empty});
        }
    }
}


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
