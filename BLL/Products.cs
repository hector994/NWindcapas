﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
namespace BLL
{
    public class Products
    {
        // crear un nuevo registro en la base de datos.
        public Product Create(Product newProduct)
        {
            Product Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                //buscar si el nmbre del productp ya existe
                Product res = r.Retrieve<Product>(p => p.ProductName == newProduct.ProductName);
                if (res==null)
                {
                    //no esxixte podemos crearlo
                    Result = r.Create(newProduct);
                }
                else
                {
                    //Prodriamos aqui lanzar una execcion
                    //para notificar que el producto ya existe
                    //podriamos incluso crear una capa de execciones personalizadas y consumirla desde otras capas.
                    //si alguien quissiera  implementar una exaccion personalizada para ser lanzada aqui
                    throw new System.Exception();

                }
            }
            return Result;
        }

        public Product RetriveByID(int ID)
        {
            Product Resultado = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Resultado = r.Retrieve<Product>(p => p.ProductID == ID);
            }
            return Resultado;
        }
        public bool Update(Product productToUpdate)
        {
            bool Result = false;
           
            using (var r = RepositoryFactory.CreateRepository())
            {
                //Validar que el nombre del producto no exista.
                Product temp = r.Retrieve<Product>(p => p.ProductName == productToUpdate.ProductName &&
                p.ProductID != productToUpdate.ProductID);
                if (temp==null)
                {
                    //no existe
                    Result = r.Update(productToUpdate);
                }
                else
                {
                    //podemos implemetar una logica  para indica que no se pudo modifica

                }
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
                if (Product.UnitsInStock==0)
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

        public List<Product> FilterByCategoryID(int categoryID)
        {
            List<Product> Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Filter<Product>(p => p.CategoryID == categoryID);
            }
            return Result;
        }
    }
}
