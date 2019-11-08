﻿using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Mock;
using OnlineRetailPortal.MongoDBStore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductStoreFactory _productStoreFactory;

        public ProductService(IProductStoreFactory productStoreFactory)
        {
            this._productStoreFactory = productStoreFactory;
        }

        public async Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest)
        {
            var store =_productStoreFactory.GetProductStore("Mock");
            var mongo = new ProductStore();
            var config = new ProductConfiguration() 
            {
                ExpiryInDays=30
            };
            Core.Product product = addProductRequest.ToEntity();
            Core.Product response = await product.SaveAsync(mongo,config);
            return response.ToModel();
        }

    }
}
