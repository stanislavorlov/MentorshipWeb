namespace MentorshipWebApp.Interface
{
    public interface IProductService
    {
        void AddProduct(Product product);

        List<Product> GetProducts();
    }
}
