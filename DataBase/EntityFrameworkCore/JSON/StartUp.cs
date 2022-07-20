using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Datasets.DataTransfer;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var productShopContext = new ProductShopContext();
            //productShopContext.Database.EnsureDeleted();
            //productShopContext.Database.EnsureCreated();


            ////01. Import Users
            //string users = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(productShopContext, users));

            ////02.Import Products
            //string products = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(productShopContext, products));

            ////03. Import Categories
            //string category = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(productShopContext, category));

            ////04 Import Categories and Products
            //string categoryProduct = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(productShopContext, categoryProduct));

            ////05. Export Products In Range
            //Console.WriteLine(GetProductsInRange(productShopContext));

            //06.Export Sold Products
            //Console.WriteLine(GetSoldProducts(productShopContext));

            //07. Export Categories By Products Count
            //Console.WriteLine(GetCategoriesByProductsCount(productShopContext));

            //08. Export Users and Products
            Console.WriteLine(GetUsersWithProducts(productShopContext));
        }

        private static void InitiazerMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();

        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {

            //01
            //var user = JsonConvert.DeserializeObject<User[]>(inputJson);

            //context.AddRange(user);
            //context.SaveChanges();

            //02 With Mapping
            //use IEnumerable from the class UserInputModel and read the JSON
            InitiazerMapper();

            var dtoUser = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUser);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            //01
            //var result = JsonConvert.DeserializeObject<Product[]>(inputJson);

            //context.AddRange(result);
            //context.SaveChanges();

            //02
            InitiazerMapper();

            var dtoProduct = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            var result = mapper.Map<IEnumerable<Product>>(dtoProduct);
            context.Products.AddRange(result);
            context.SaveChanges();

            return $"Successfully imported {result.Count()}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitiazerMapper();

            var dtoCategories = JsonConvert
                .DeserializeObject<IEnumerable<CategoriesInputModel>>(inputJson)
                .Where(x => x.Name != null)
                .ToList();

            var result = mapper.Map<IEnumerable<Category>>(dtoCategories);
            context.Categories.AddRange(result);
            context.SaveChanges();

            return $"Successfully imported {result.Count()}";
        }

        //04 Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitiazerMapper();

            var dtoCatProd = JsonConvert.DeserializeObject<IEnumerable<CategoriesProductsModel>>(inputJson);

            var result = mapper.Map<IEnumerable<CategoryProduct>>(dtoCatProd);
            context.CategoryProducts.AddRange(result);
            context.SaveChanges();


            return $"Successfully imported {result.Count()}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(x => x.price)
                .ToArray();

            string result = JsonConvert.SerializeObject(products, Formatting.Indented);

            return result;
        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldItem = context.Users
                .Where(x => x.ProductsSold.Any(b => b.BuyerId != null))
                .Select(s => new
                {
                    firstName = s.FirstName,
                    lastName = s.LastName,
                    soldProducts = s.ProductsSold.Where(p => p.BuyerId != null)
                        .Select(b => new
                        {
                            name = b.Name,
                            price = b.Price,
                            buyerFirstName = b.Buyer.FirstName,
                            buyerLastName = b.Buyer.LastName
                        }).ToArray()
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToArray();

            string result = JsonConvert.SerializeObject(soldItem, Formatting.Indented);

            return result;
        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count(),
                    averagePrice = c.CategoryProducts.Average(x => x.Product.Price).ToString("f2"),
                    totalRevenue = c.CategoryProducts.Sum(x => x.Product.Price).ToString("f2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToArray();

            string result = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return result;
        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .ToList()
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Where(p => p.BuyerId != null).Count(),
                        products = u.ProductsSold.Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                    }
                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToList();

            var newObjectOfUsers = new
            {
                usersCount = users.Count,
                users = users

            };

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            };

            return JsonConvert.SerializeObject(newObjectOfUsers, settings);
        }
    }
}