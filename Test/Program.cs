using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entities;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddProduct();
            //RetrieveAndUpdate();
            List();
            Console.WriteLine("Presiones<enter> para finalizar");
            Console.ReadLine();
        }
        static void AddCategoryAndProduct()
        {
            Category c = new Category()
            {
                CategoryName = "Cereales",
                Description = "Productos de Maiz"
               
            };
            Product Cereal = new Product
            {
                ProductName = "Cereal",UnitsInStock = 0,UnitPrice = 15
            };
            c.Products.Add(Cereal);

            using (var r = RepositoryFactory.CreateRepository())//Todo lo que esta en el using se libera los recurso, se invoca el dispos
            {
                r.Create(c);
            }
            Console.WriteLine
                    ($"Categoria:{c.CategoryID}," + $"Producto:{Cereal.ProductID}");
        }

        static void AddProduct()
        {
            Product Avena = new Product
            {
                CategoryID=1,UnitsInStock=100,ProductName="Avena",UnitPrice = 10
            };
            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(Avena);
            }
            Console.WriteLine($"Producto:{Avena.ProductID}");
        }
        //Buscar y Modificar
        static void RetrieveAndUpdate()
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                //Buscar el ultimo producto agregado
                Product P = r.Retrieve<Product>(p => p.ProductID == 2);
                if (P != null)
                {
                    Console.Write(P.ProductName);
                    P.ProductName = P.ProductName + "######";
                    r.Update(P);
                    Console.WriteLine("Nombre modificado");
                    
                }
            }
        }

        static void List()
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                var Categories = r.Filter<Category>(c => true);
                //var products = r.Filter<Product>(p => p.ProductName.Contains("ae"))
                //.OrderByDescending(p => p.ProductName);
                var Products = r.Filter<Product>(p => true); 
                //foreach (var P in products)
                //{
                //    Console.WriteLine($"{P.ProductName}");
                //}
                //Inne Join
                var ListProduct = from prod in Products
                                  join cate in Categories on prod.CategoryID equals cate.CategoryID
                                  select new
                                  {
                                      productsname = prod.ProductName,
                                      categoriesname = cate.CategoryName
                                       };
                foreach (var P in ListProduct)
                {
                    Console.WriteLine($"{P.productsname},{P.categoriesname}");
                }
            }
                
        }

        static void SearchAndDelete()
        {
            using (var R = RepositoryFactory.CreateRepository())
            {
                var P = R.Retrieve<Product>(p => p.ProductID == 2);
                if (P !=null)
                {
                    Console.WriteLine(P.ProductName);
                    R.Delete(P);
                    Console.WriteLine("Producto eliminado");
                }
                else
                {
                    Console.WriteLine("Product no encontrado");
                }
            }
        }
    }


}
