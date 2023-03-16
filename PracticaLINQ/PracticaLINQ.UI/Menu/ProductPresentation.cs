using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using PracticaLINQ.Services.Service;
using PracticaLINQ.Services.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace PracticaLINQ.UI.Menu
{
    public class ProductPresentation
    {
        private readonly IProductService _productService;
        public ProductPresentation()
        {
            _productService = new ProductService();
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
                saveList = _productService.GetProductsOrderedByName(selectOrderBy);
            }
            else if (select == "puntoDiez")
            {
                Console.Write("ordenados por unidades en stock \n");
                bool selectOrderBy = bool.Parse((ConfigurationManager.AppSettings["selectOrderBy"]));
                saveList = _productService.GetProductsOrderedByUnitsInStock(selectOrderBy);
            }
            else
            {
                MenuPrincipal.WriteIncorrectOption();
                return;
            }
            if (saveList != null)
            {
                foreach (var product in saveList)
                {
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------- \n");
                    Console.WriteLine($"Nombre del producto: {product.ProductName}");
                    Console.WriteLine($"ID Proveedor: {product.SupplierID}");
                    Console.WriteLine($"ID Categoria: {product.CategoryID}");
                    Console.WriteLine($"Cantidad por unidad: {product.QuantityPerUnit}");
                    Console.WriteLine($"Precio por unidad: {product.UnitPrice}");
                    Console.WriteLine($"Unidades en stock: {product.UnitsInStock}");
                    Console.WriteLine($"Unidades en ordenes: {product.UnitsOnOrder}");
                    Console.WriteLine($"Nivel de reordenamiento: {product.ReorderLevel}");
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
                product = _productService.GetProduct();
            }
            else
            {
                MenuPrincipal.WriteIncorrectOption();
                return;
            }
            if (product != null)
            {
                Console.WriteLine("");
                Console.WriteLine("--------------------------------- \n");
                Console.WriteLine($"Nombre del producto: {product.ProductName}");
                Console.WriteLine($"ID Proveedor: {product.SupplierID}");
                Console.WriteLine($"ID Categoria: {product.CategoryID}");
                Console.WriteLine($"Cantidad por unidad: {product.QuantityPerUnit}");
                Console.WriteLine($"Precio por unidad: {product.UnitPrice}");
                Console.WriteLine($"Unidades en stock: {product.UnitsInStock}");
                Console.WriteLine($"Unidades en ordenes: {product.UnitsOnOrder}");
                Console.WriteLine($"Nivel de reordenamiento: {product.ReorderLevel}");
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
                Console.WriteLine($"No se encontro el producto \n");
            }
        }
        public void WriteProductCategoriesList()
        {
            Console.Clear();
            Console.Title = "Mostrar categorias con productos asociados";
            Console.WriteLine($"Productos agrupados por categorias");
            List<ProductCategoriesDTO> product = _productService.GetProductCategoriesGrupBy();
            if (product != null)
            {
                foreach (var item in product)
                {
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------- \n");
                    Console.WriteLine($"Nombre de la categoria: {item.categoryName}");
                    Console.WriteLine($"Productos asociados: {item.productName}");
                }
            }
            else
            {
                Console.WriteLine("");
            }
        }
    }
}
