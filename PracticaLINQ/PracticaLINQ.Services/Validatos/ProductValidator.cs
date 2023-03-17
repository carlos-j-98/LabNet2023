using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace PracticaLINQ.Services.Validatos
{
    public class ProductValidator
    {
        public ProductValidator() { }
        public bool IsNullProductValidator(Products product)
        {
            if (product == null)
            {
                throw new InvalidOperationException(ConfigurationManager.AppSettings["invalidOperationProdText"]);
            }
            return true;
        }
        public bool IsNullProductsListValidator(List<Products> product)
        {
            if (product == null || product.Count == 0)
            {
                throw new InvalidOperationException(ConfigurationManager.AppSettings["invalidOperationProdText"]);
            }
            return true;
        }
        public bool IsNullProductCategories(List<ProductCategoriesDTO> product)
        {
            if (product == null || product.Count == 0)
            {
                throw new InvalidOperationException(ConfigurationManager.AppSettings["invalidOperationProdText"]);
            }
            return true;
        }
    }
}
