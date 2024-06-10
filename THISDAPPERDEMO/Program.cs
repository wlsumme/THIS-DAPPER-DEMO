using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ConsoleApp1;
using DapperDemo;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var depRepo = new DepartmentRepo(conn);

//Console.WriteLine("Enter depo name to create");
//var depoName = Console.ReadLine();
//depRepo.InsertDepartment(depoName);

//var departments = depRepo.GetAllDepartments(); 


//foreach (var dep in departments)
//{
//    Console.WriteLine($"ID: {dep.DepartmentID} | Name: {dep.Name}");
//}

var productRepo = new ProductRepo(conn);

//productRepo.CreateProduct("MyHAmSamdwitch Kit", 12.99, 8, true, 45);

//productRepo.UpdateProduct(952, "How cAres");

productRepo.DeleteProduct(947);

var products = productRepo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine($"ID: {product.ProductID} Name :{product.Name} | Category ID: {product.CategoryID} | On Sale: {product.OnSale} | Stock Level {product.StockLevel}  ");
}


