namespace WebApplication1.Repositories
{
    public interface IProductRepo
    {
        void Create(Product product);
    }

    public class ProductRepo : IProductRepo
    {
        private List<Product> _products;

        public ProductRepo()
        {
            _products = new List<Product>();
        }

        public void Create(Product product)
        {
            _products.Add(product);
        }
    }
}
