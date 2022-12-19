using XTL;

// class này dùng để đăng ký DI vào thêm vào ProductBox
public class ProductListService 
{
    public List<Product> products {get; set; } = new List<Product>() {
            new Product() {Name = "Sản phẩm 1", Desciptions = "Mô tả sản phẩm 1", Price = 6000},
            new Product() {Name = "Sản phẩm 2", Desciptions = "Mô tả sản phẩm 2", Price = 4000},
            new Product() {Name = "Sản phẩm 3", Desciptions = "Mô tả sản phẩm 3", Price = 3000},
            new Product() {Name = "Sản phẩm 4", Desciptions = "Mô tả sản phẩm 4", Price = 2000},
            new Product() {Name = "Sản phẩm 5", Desciptions = "Mô tả sản phẩm 5", Price = 5000},
            new Product() {Name = "Sản phẩm 6", Desciptions = "Mô tả sản phẩm 6", Price = 2200},
            };
}