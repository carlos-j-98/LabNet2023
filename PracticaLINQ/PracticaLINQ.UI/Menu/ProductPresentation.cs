using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using PracticaLINQ.Logic.LogicBusiness;
using PracticaLINQ.Logic.LogicBusiness.LogicInterfaces;
using PracticaLINQ.Services.Validatos;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace PracticaLINQ.UI.Menu
{
    public class ProductPresentation
    {
        private readonly IProductLogic _productService;
        private readonly ProductValidator _productValidator;
        public ProductPresentation()
        {
            _productService = new ProductLogic();
            _productValidator = new ProductValidator();
        }
        public void WriteListProducts(string select)
        {
            Console.Clear();
            Console.Title = "Mostrar productos";
            Console.Write("Mostrando lista de productos ");
            List<Products> saveList;
            if (select == "puntoDos")
            {
                Console.Write("sin stock \n");
                saveList = _productService.GetNoStockProducts();
            }
            else if (select == "puntoTres")
            {
                Console.Write("con stock y que valen mas de 3 por unidad \n");
                saveList = _productService.GetStockProductsStockThreePerUnits();
            }
            else if (select == "puntoNueve")
            {
                Console.Write("ordenados por nombre \n");
                bool selectOrderBy = bool.Parse((ConfigurationManager.AppSettings["selectOrderBy"]));
                saveList = _productService.GetProductsOrderedByName(selectOrderBy) ?? null;
            }
            else if (select == "puntoDiez")
            {
                Console.Write("ordenados por unidades en stock \n");
                bool selectOrderBy = bool.Parse((ConfigurationManager.AppSettings["selectOrderBy"]));
                saveList = _productService.GetProductsOrderedByUnitsInStock(selectOrderBy) ?? null;
            }
            else
            {
                MenuPrincipal.WriteIncorrectOption();
                return;
            }
            if (_productValidator.IsNullProductsListValidator(saveList))
            {
                foreach (var product in saveList)
                {
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------- \n");
                    Console.WriteLine($"Nombre del producto: {product.ProductName.ToString() ?? "Desconocido"}");
                    Console.WriteLine($"ID Proveedor: {product.SupplierID.ToString() ?? "Desconocido"}");
                    Console.WriteLine($"ID Categoria: {product.CategoryID.ToString() ?? "Desconocido"}");
                    Console.WriteLine($"Cantidad por unidad: {product.QuantityPerUnit.ToString() ?? "Desconocido"}");
                    Console.WriteLine($"Precio por unidad: {product.UnitPrice.ToString() ?? "Desconocido"}");
                    Console.WriteLine($"Unidades en stock: {product.UnitsInStock.ToString() ?? "Desconocido"}");
                    Console.WriteLine($"Unidades en ordenes: {product.UnitsOnOrder.ToString() ?? "Desconocido"}");
                    Console.WriteLine($"Nivel de reordenamiento: {product.ReorderLevel.ToString() ?? "Desconocido"}");
                    if (product.Discontinued)
                    {
                        Console.WriteLine($"Discontinuado: Discontinuado");
                    }
                    else
                    {
                        Console.WriteLine($"Discontinuado: En continuidad");
                    }
                }
            }
        }
        public void WriteProdutc(string select)
        {
            Console.Clear();
            Console.Title = "Mostrar producto";
            Products product;
            if (select == "puntoCinco")
            {
                int productID = int.Parse(ConfigurationManager.AppSettings["productIDPuntoCinco"]);
                Console.WriteLine($"Buscando producto con ID: {productID} \n");
                product = _productService.GetProduct(productID);
            }
            else if (select == "puntoDoce")
            {
                Console.WriteLine($"Buscando el primer producto de una lista \n");
                product = _productService.GetOneProduct();
            }
            else
            {
                MenuPrincipal.WriteIncorrectOption();
                return;
            }
            WriteProductExist(product);
        }
        public void WriteProductExist(Products product) 
        {

            if (product != null) 
            {
                Console.WriteLine("");
                Console.WriteLine("--------------------------------- \n");
                Console.WriteLine($"Nombre del producto: {product.ProductName ?? "Desconocido"}");
                Console.WriteLine($"ID Proveedor: {product.SupplierID.ToString() ?? "Desconocido"}");
                Console.WriteLine($"ID Categoria: {product.CategoryID.ToString() ?? "Desconocido"}");
                Console.WriteLine($"Cantidad por unidad: {product.QuantityPerUnit.ToString() ?? "Desconocido"}");
                Console.WriteLine($"Precio por unidad: {product.UnitPrice.ToString() ?? "Desconocido"}");
                Console.WriteLine($"Unidades en stock: {product.UnitsInStock.ToString() ?? "Desconocido"}");
                Console.WriteLine($"Unidades en ordenes: {product.UnitsOnOrder.ToString() ?? "Desconocido"}");
                Console.WriteLine($"Nivel de reordenamiento: {product.ReorderLevel.ToString() ?? "Desconocido"}");
                Console.Write("Estado:");
                if (product.Discontinued)
                {
                    Console.Write("Discontinuado");
                }
                else
                {
                    Console.Write("En continuidad");
                }
            }
            else 
            {
                Console.WriteLine("El producto es nulo \n");
            }
        }
        public void WriteProductCategoriesList()
        {
            Console.Clear();
            Console.Title = "Mostrar categorias con productos asociados";
            Console.WriteLine($"Productos agrupados por categorias");
            List<ProductCategoriesDTO> product = _productService.GetProductCategoriesGrupBy();
            if (_productValidator.IsNullProductCategories(product))
            {
                foreach (var item in product)
                {
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------- \n");
                    Console.WriteLine($"Nombre de la categoria: {item.categoryName ?? "Desconocido"}");
                    Console.WriteLine($"Productos asociados: {item.productName ?? "Desconocido"}");
                }
            }
        }
    }
}
