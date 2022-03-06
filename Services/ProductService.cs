using System;
using System.Collections.Generic;
using App.Models;
namespace App.Services{
    public class ProductService{
        private List<ProductModel> products = new List<ProductModel>();
        public ProductService(){
            products.AddRange(new ProductModel[]{
                new ProductModel(){Id=1,Name="IPhone X",Price=900},
                new ProductModel(){Id=2,Name="IPhone XR",Price=950},
                new ProductModel(){Id=3,Name="IPhone XS",Price=1050},
                new ProductModel(){Id=4,Name="IPhone 11",Price=1250},
                new ProductModel(){Id=5,Name="IPhone 12",Price=1350}
            });
        }
        public List<ProductModel> GetProducts(){
            return products;
        }
    }
}