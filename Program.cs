using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STACK2
{
    public interface IRepository<T>
    {
        void Add(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T item);
        void Delete(int id);
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    
    public class ProductRepository : IRepository<Product>
    {
        private List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>();
        }

        public void Add(Product item)
        {
            products.Add(item);
            Console.WriteLine($"Product '{item.Name}' added to the repository.");
        }

        public Product GetById(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public void Update(Product item)
        {
            Product existingProduct = products.Find(p => p.Id == item.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = item.Name;
                existingProduct.Price = item.Price;
                Console.WriteLine($"Product with ID {item.Id} updated in the repository.");
            }
            else
            {
                Console.WriteLine($"Product with ID {item.Id} not found in the repository.");
            }
        }

        public void Delete(int id)
        {
            Product productToRemove = products.Find(p => p.Id == id);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                Console.WriteLine($"Product with ID {id} deleted from the repository.");
            }
            else
            {
                Console.WriteLine($"Product with ID {id} not found in the repository.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
         
            ProductRepository productRepository = new ProductRepository();

            Product laptop = new Product { Id = 1, Name = "Laptop", Price = 1200.0 };
            Product smartphone = new Product { Id = 2, Name = "Smartphone", Price = 800.0 };

            productRepository.Add(laptop);
            productRepository.Add(smartphone);

            Console.WriteLine("\nAll Products in the Repository:");
            foreach (var product in productRepository.GetAll())
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }

            Product updatedLaptop = new Product { Id = 1, Name = "Updated Laptop", Price = 1500.0 };
            productRepository.Update(updatedLaptop);

            Console.WriteLine("\nAll Products in the Repository after Update:");
            foreach (var product in productRepository.GetAll())
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }

            productRepository.Delete(2);

            Console.WriteLine("\nAll Products in the Repository after Delete:");
            foreach (var product in productRepository.GetAll())
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
        }
    }
}
