using Demo.WebApi.NetCore.Dapper.Interfaz;
using Demo.WebApi.NetCore.Entities.Models;
using System;
using System.Collections.Generic;
using Dapper;
using Demo.WebApi.NetCore.Dapper.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Demo.WebApi.NetCore.Dapper.Repository
{
    public class AlumnoService : IAlumnoService
    {
        Product product = new Product();
        List<Product> products = new List<Product>();

        public string Delete(int productId)
        {
            string message = "";

            try
            {

            }
            catch (Exception ex) 
            {

                message = ex.Message;
            }
            return message;

        }

        public Product Get(int productId)
        {
            product = new Product();

            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                var result = con.Query<Product>("SELECT * FROM Product WHERE ProductID = " + productId).ToList();

                if (products != null && products.Count() > 0)
                {
                    product = result.SingleOrDefault();
                }
            }
            return product;
        }

        public List<Product> Gets()
        {

            products = new List<Product>();

            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                var result = con.Query<Product>("SELECT * FROM Product").ToList();

                if (products != null && products.Count() > 0)
                {
                    products = result;
                }
            }
            return products;
        }

        public Product Save(Product product)
        {
            product = new Product();

            try
            {
                int operationType = Convert.ToInt32(product.ProductID == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var products = con.Query<Product>("Usp_Product"
                        , this.SetParameters(product, operationType)
                        , commandType: CommandType.StoredProcedure);
                    if (products != null && products.Count() > 0)
                    {
                        product = products.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                product.Message = ex.Message;
            }
            return product;
        }

        private DynamicParameters SetParameters(Product product, int operationType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductID", product.ProductID);
            parameters.Add("@Nombre", product.Nombre);
            parameters.Add("@Precio", product.Precio);
            parameters.Add("@Stock", product.Stock);
            parameters.Add("@CategoryID", product.CategoryID);
            parameters.Add("@OperationType", operationType);
            return parameters;
        }
    }
}
