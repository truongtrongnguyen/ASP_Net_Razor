public class ProductService
{

    public ProductService()
    {
        LoadProducts();
    }
    private List<Product> products = new List<Product>();
    public void LoadProducts()
    {
        products.Clear();
        products.Add(new Product() {id = 1, Name = "IPhone 11", Descriptions = "Hãng Apple", Price = 1000});
        products.Add(new Product() {id = 2, Name = "IPhone 12", Descriptions = "Hãng Apple", Price = 2000});
        products.Add(new Product() {id = 3, Name = "IPhone 13", Descriptions = "Hãng Apple", Price = 3000});
    }
    public Product Find(int id)
    {
        var product = from p in products where p.id == id select p;
        return product.FirstOrDefault(); 
    }   

    public List<Product> AllProduct() => products;
}

// Sau đó ta đăng ký nó vào như là một dịch vụ