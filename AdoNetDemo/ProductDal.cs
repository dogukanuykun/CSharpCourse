using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo
{
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade; integrated security=true");
        public List<Product> GelAll()
        {
            ConnectionControl();   
            
            SqlCommand command = new SqlCommand("SELECT * FROM PRODUCTS", _connection);
            
            SqlDataReader reader = command.ExecuteReader();

            List<Product> products= new List<Product>();
            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = Convert.ToString(reader["Name"]),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
                products.Add(product);
            }

            reader.Close();
            _connection.Close();
            return products;
        }

        public void Add(Product product)
        {
            ConnectionControl();

            SqlCommand sqlCommand = new SqlCommand(
                "insert into products values(@name, @unitPrice, @stockAmount)", _connection) ;
            sqlCommand.Parameters.AddWithValue("@name", product.Name);
            sqlCommand.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            sqlCommand.ExecuteNonQuery();

            _connection.Close() ;
        }
        public void Update(Product product)
        {
            ConnectionControl();

            SqlCommand sqlCommand = new SqlCommand(
                "update products set Name = @name, UnitPrice = @unitPrice, StockAmount=@stockAmount where Id = @id", _connection);
            sqlCommand.Parameters.AddWithValue("@name", product.Name);
            sqlCommand.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            sqlCommand.Parameters.AddWithValue("@id", product.Id);
            sqlCommand.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int id)
        {
            ConnectionControl();

            SqlCommand sqlCommand = new SqlCommand(
                "delete from products where Id = @id", _connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();

            _connection.Close();
        }

        private void ConnectionControl()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
    }
}
