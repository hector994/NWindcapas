using System;
using System.Collections.Generic;
using System.Text;
using Entities;
namespace SLC
{
    public interface IService
    {
        #region OPeraciones con products
        Product CreateProduct(Product newProduct);
        Product RetriveProductByID(int ID);
        bool UpdateProductByID(Product productToUpdate);
        bool DeleteProduct(int ID);
        List<Product> FilterProductsByCategoryID(int categoryID);
        #endregion

        #region Operaciones con categories 
        Category CreateCategory(Category newCategory);
        Category RetriveCategoryByID(int ID);
        bool UpdateCategory(Category categoryToUpdate);
        bool DeleteCategory(int ID);
        List<Category> GetCategories();
        #endregion
    }
}
