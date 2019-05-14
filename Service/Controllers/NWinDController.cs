using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using BLL;
using SLC;


namespace Service.Controllers
{
    public class NWinDController : ApiController, IService
    {
        [HttpPost]
        public Category CreateCategory(Category newCategory)
        {
            var BLL = new Categories();
            var NewCategory = BLL.Create(newCategory);
            return NewCategory;
        }
        [HttpPost]
        public Product CreateProduct(Product newProduct)
        {
            var BLL = new Products();
            var NewProduct= BLL.Create(newProduct);
            return NewProduct;
        }
        [HttpGet]
        public bool DeleteCategory(int ID)
        {
            var BLL = new Categories();
            var DeleteCategory = BLL.Delete(ID);
            return DeleteCategory;
        }
        [HttpGet]
        public bool DeleteProduct(int ID)
        {
            var BLL = new Products();
            var Result = BLL.Delete(ID);
            return Result;
        }
        [HttpGet]
        public List<Product> FilterProductsByCategoryID(int categoryID)
        {
            var BLL = new Products();
            var Result = BLL.FilterByCategoryID(categoryID);
          

            return Result;
        }

        [HttpGet]
        public List<Product> Filter(int categoryID)
        {
            var BLL = new Products();
            var Result = BLL.FilterByCategoryID(categoryID);


            return Result;
        }

        [HttpGet]
        public List<Category> GetCategories()
        {
            var BLL = new Categories();
            var ListByCategory = BLL.GetCategories();
            return ListByCategory;
        }
        [HttpGet]
        public Category RetriveCategoryByID(int ID)
        {
            var BLL = new Categories();
            var retriveCategoryByID = BLL.RetriveByID(ID);
            return retriveCategoryByID;
        }
        [HttpGet]
        public Product RetriveProductByID(int ID)
        {
            var BLL = new Products();
            var retriveProductByID = BLL.RetriveByID(ID);
            return retriveProductByID;
        }
        [HttpPost]
        public bool UpdateCategory(Category categoryToUpdate)
        {
            var BLL = new Categories();
            var updateCategory = BLL.Update(categoryToUpdate);
            return updateCategory;
        }
        [HttpPost]
        public bool UpdateProductByID(Product productToUpdate)
        {
            var BLL = new Products();
            var updateProductByID = BLL.Update(productToUpdate);
            return updateProductByID;
        }
    }
}
