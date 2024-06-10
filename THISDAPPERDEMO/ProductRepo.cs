using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
    public class ProductRepo : IProductRepo
    {

        private readonly IDbConnection _conn;

        public ProductRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public void CreateProduct(string name, double price, int categoryID, bool onSale, int stockLevel)
        {
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID, OnSale, StockLevel) VALUES (@name, @price, @categoryID, @onSale, @stockLevel);", new { name, price, categoryID, onSale, stockLevel });
        }

        public void DeleteProduct(int productID)
        {
            _conn.Execute("DELETE FROM reviews WHERE ProductID = @productID", new { productID });
            _conn.Execute("DELETE FROM sales WHERE ProductID = @productID", new { productID });
            _conn.Execute("DELETE FROM products WHERE ProductID = @productID", new { productID });
        }

        public IEnumerable<Product> GetAllProducts()
        {

            return _conn.Query<Product>("SELECT * FROM products;");
        }

        public void UpdateProduct(int productID, string newName)
        {
            _conn.Execute("UPDATE products SET Name = @newName WHERE ProductID = @productID", new { newName, productID });
        }
    }


}
