using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernatePostgre.Domains;
using NHibernatePostgre.Services;

namespace NHibernatePostgre.ConsoleTests
{
    public class TestDb
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public TestDb(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public void Run()
        {
            var category1 = new Category
            {
                CategoryTitle = "Category 1"
            };
            category1.Id = _categoryService.AddEntry(category1);
            Console.WriteLine($"category id : {category1.Id}");

            var category2 = new Category
            {
                CategoryTitle = "Category 1"
            };
            category2.Id = _categoryService.AddEntry(category2);
            Console.WriteLine($"category id : {category2.Id}");

            var product = new Product
            {
                ProductTitle = "Product 1"
            };
            product.Id = _productService.AddEntry(product);
            Console.WriteLine($"product id : {product.Id}");

            product.Categories = new HashSet<Category>
            {
                category1
            };
            _productService.MergeEntry(product);

            Console.WriteLine($"category id : {category1.Id}");
            Console.WriteLine($"product id : {product.Id}");
        }
    }
}
