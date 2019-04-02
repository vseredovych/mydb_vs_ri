﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace MyDbVsRi.TablesRepository
{

    class ProductsRepository
    {
        List<Product> Products;

        public ProductsRepository()
        {
            Products = new List<Product>();
        }
        public void AddTorepository(Product product)
        {
            Products.Add(product);
        }
        public void FillRepositoryByDataReader(DbDataReader reader)
        {
            for (int i = 0; i < reader.Dictionary["Id"].Count; i++)
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(reader.Dictionary["Id"][i]);
                product.Name = Convert.ToString(reader.Dictionary["Name"][i]);
                product.Price = Convert.ToDouble(reader.Dictionary["Price"][i]);
                product.Status = Convert.ToString(reader.Dictionary["Status"][i]);
                product.MerchantId = Convert.ToInt32(reader.Dictionary["MerchantId"][i]);
                product.CreatedAt = Convert.ToDateTime(reader.Dictionary["CreatedAt"][i]);
                Products.Add(product);
            }
        }
        public void WriteProducts()
        {
            foreach (Product merchant in Products)
            {
                Console.WriteLine(merchant);
            }
        }
    }
}

