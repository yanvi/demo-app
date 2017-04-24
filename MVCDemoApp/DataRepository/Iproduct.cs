using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDemoApp.Models;

namespace MVCDemoApp.DataRepository
{
    interface Iproduct
    {
         int Id { get; set; }
         string Name { get; set; }
         string Category { get; set; }
         decimal Price { get; set; }
         int ADDProduct(Product product);
         int UpdateProduct(Product product);
         int DeleteProduct(int ProductId);
         IEnumerable<Product> GetAllProduct();
         Product GetProductById(int ProductId);
    }
    public class ProductContext:Iproduct
    {

        private static List<Product> products;
      
        public ProductContext()
        {
            products = new List<Product>();
        }
        public int Id
        {
            get
            {
                return this.Id;
            }
            set
            {
                this.Id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.Name;
            }
            set
            {
                this.Name = value;
            }
        }

        public string Category
        {
            get
            {
                return this.Category;
            }
            set
            {
                this.Category = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.Price;
            }
            set
            {
                this.Price = value;
            }
        }

        public int ADDProduct(Product product)
        {
            if (product != null)
            {
                products.Add(product);
                return 1;
            }
            return 0;
        }

        public int UpdateProduct(Product product)
        {
            if (product != null)
            {
            Product _product= products.FirstOrDefault(p => p.Id ==product.Id);
            if (_product != null)
            {
                _product.Name = product.Name;
                _product.Price = product.Price;
                _product.Category = product.Category;
                return 1;
            }
                
            }
            return 0;
        }

        public int DeleteProduct(int ProductId)
        {
         
                Product _product = products.FirstOrDefault(p => p.Id == ProductId);
                if(_product==null)
                {
                    return 0;
                }
                products.Remove(_product);
                return 1;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return products;
        }

        public Product GetProductById(int ProductId)
        {
          return  products.Where(p => p.Id == ProductId).FirstOrDefault();
        }


        
    }
}
