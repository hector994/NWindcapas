using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Newtonsoft.Json;
using SLC;
namespace NWindProxyService
{
    public class Proxy : IService
    {
        string BaseAddress = "http://localhost:60789/";

        public async Task<T> SendPost<T, PostData>(string requestURI,PostData data)
        {
            T Result=default(T);
            using (var Client= new HttpClient())
            {
                try
                {
                    //URL Absoluto
                    requestURI = BaseAddress + requestURI;
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add
                        (new MediaTypeWithQualityHeaderValue("application/json"));

                    var JSONData = JsonConvert.SerializeObject(data);
                    HttpResponseMessage Response = 
                        await Client.PostAsync
                        (requestURI, new StringContent
                        (JSONData.ToString(), Encoding.UTF8, "application/json"));

                    var ResultWebAPI = await Response.Content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<T>(ResultWebAPI);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Result;
        }

        public async Task<T> SendGet<T>(string requestURL)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    requestURL = BaseAddress + requestURL;

                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add
                        (new MediaTypeWithQualityHeaderValue("application/json"));

                    var ResultJSON = await Client.GetStringAsync(requestURL);
                    Result = JsonConvert.DeserializeObject<T>(ResultJSON);
                }
                catch (Exception)
                {

                    throw;
                }
                return Result;
            }
        }

        public async Task<Category> CreateCategoryAsync(Category newCategory)
        {
            return await SendPost<Category,Category>($"/api/nwind/createcategory",newCategory);
        }
        public Category CreateCategory(Category newCategory)
        {
            Category Result = null;
            Task.Run(async () => Result = await CreateCategoryAsync(newCategory)).Wait();
            return Result;
        }

        public async Task<Product> CreateProductAsync(Product newProduct)
        {
            return await SendPost<Product, Product>("/api/nwind/createproduct",newProduct);
        }
        public Product CreateProduct(Product newProduct)
        {
            Product Result = null;
            Task.Run(async () => Result = await CreateProductAsync(newProduct)).Wait();
            return Result;
        }
        public async Task<Category> DeleteCategoryAsync(Category deleteCategory)
        {
            throw new NotImplementedException();
        }
        public bool DeleteCategory(int ID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int ID)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Product>> FilterProductsByCategoryIDAsync(int ID)
        {
            return await SendGet<List<Product>>($"/api/nwind/FilterProductsByCategoryID/{ID}");
        }
        public List<Product> FilterProductsByCategoryID(int categoryID)
        {
            List<Product> Result = null;
            Task.Run(async () => Result = await FilterProductsByCategoryIDAsync(categoryID)).Wait();
            return Result;
        }
        /// <summary>
        /// //asinrono
        /// </summary>
        /// <returns></returns>
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await SendGet<List<Category>>($"/api/nwind/GetCategories");
        }
        public List<Category> GetCategories()
        {
            List<Category> Result = null;
            Task.Run(async () => Result = await GetCategoriesAsync());
            return Result;
        }

        //implemente una vercion saincrona
        public async Task<Category> RetriveCategoryByIDAsync(int ID)
        {
            return await SendGet<Category>($"/api/nwind/RetriveCategoryByID/{ID}");
        }
        public Category RetriveCategoryByID(int ID)
        {
            Category Result = null;
            Task.Run(async () => Result = await RetriveCategoryByIDAsync(ID)).Wait();
            return Result;
        }
        //implementar una version asyncrona
        public async Task<Product> RetrivrProductByIDAsync(int ID)
        {
            return await SendGet<Product>($"/api/nwind/RetriveProductByID/{ID}");
        }
        public Product RetriveProductByID(int ID)
        {
            Product Result = null;
            Task.Run(async () => Result = await RetrivrProductByIDAsync(ID)).Wait();
            return Result;
        }
        public async Task<bool> UpdateCategoryAsync(Category categoryToUpdate)
        {
            return await SendPost<bool, Category>("api/nwind/UpdateCategory", categoryToUpdate);
        }
        public bool UpdateCategory(Category categoryToUpdate)
        {
            bool Result = false;
            Task.Run(async () => Result = await UpdateCategoryAsync(categoryToUpdate)).Wait();
            return Result;
        }
        public async Task<bool> UpdateProductAsync(Product productToUpdate)
        {
            return await SendPost<bool, Product>("api/nwind/UpdateProduct", productToUpdate);
        }
        public bool UpdateProductByID(Product productToUpdate)
        {
            bool Result = false;
            Task.Run(async () => Result = await UpdateProductAsync(productToUpdate)).Wait();
            return Result;
        }
    }
}
