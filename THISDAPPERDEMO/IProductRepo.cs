using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
    public interface IProductRepo
    {

        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(string name, double price, int categoryID, bool onSale, int stockLevel);

        public void UpdateProduct(int productID, string newName);

        public void DeleteProduct(int productID);
    }
}
