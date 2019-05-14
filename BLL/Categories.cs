using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    public class Categories
    {
        public Category Create(Category newCategory)
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                newCategory = r.Create(newCategory);
            }
            return newCategory;
        }

        public Category RetriveByID(int ID)
        {
            Category Resultado = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Resultado = r.Retrieve<Category>(p => p.CategoryID == ID);
            }
            return Resultado;
        }
        public bool Update(Category categoryToUpdate)
        {
            bool Result = false;

            using (var r = RepositoryFactory.CreateRepository())
            {
                //Validar que el nombre del producto no exista.
                Category temp = r.Retrieve<Category>(p => p.CategoryName == categoryToUpdate.CategoryName &&
                p.CategoryID != categoryToUpdate.CategoryID);
                if (temp == null)
                {
                    //no existe
                    Result = r.Update(categoryToUpdate);
                }
                //else
               // {
                    //podemos implemetar una logica  para indica que no se pudo modifica

               // }
            }
            return Result;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            ///buscar el producto para ver si tiene existencias 
            var Product = RetriveByID(ID);
            if (Product != null)
            {
                if (Product.CategoryID == 0)
                {
                    //eliminbar producto
                    using (var r = RepositoryFactory.CreateRepository())
                    {
                        Result = r.Delete(Product);
                    }
                }
                else
                {
                    //podemos implementat algunaa logica adicional para indicar que el producto no se pudo eliminar
                }
            }
            else
            {
                //el producto non exixte 

            }

            return Result;
        }

        public List<Category> GetCategories()
        {
            List<Category> Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Filter<Category>(c=>true);
            }
            return Result;
        }
    }
}
