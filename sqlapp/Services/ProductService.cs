using Microsoft.Data.SqlClient;
using sqlapp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace sqlapp.Services
{
    public class ProductService
    {
        private SqlConnection GetConnection(string _connection_string)
        {
            return new SqlConnection(_connection_string);
        }

        public IEnumerable<Product> GetProducts(string _connection_string)
        {
            List<Product> _list = new List<Product>();
            string _statement = "SELECT product_name, category, price, stock_quantity FROM products";
            SqlConnection _connection = GetConnection(_connection_string);
            _connection.Open();
            SqlCommand _sqlCommand = new SqlCommand(_statement, _connection);
            using (SqlDataReader _reader = _sqlCommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Product product = new Product()
                    {
                        product_name = _reader.GetString(0),
                        category = _reader.GetString(1),
                        price = _reader.GetDecimal(2),
                        stock_quantity = _reader.GetInt32(3)
                    };
                    _list.Add(product);
                }
            }
            _connection.Close();
            return _list;

        }



    }
}
