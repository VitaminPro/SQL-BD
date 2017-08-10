using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithBD
{
    class SportProductShop
    {
      

        private SqlConnection sqlConnection;

        public SportProductShop()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ринат\Documents\Visual Studio 2015\Projects\WorkingWithBD\WorkingWithBD\Database.mdf;Integrated Security=True"; //получаем физическое расположение нашей базы данных
            sqlConnection = new SqlConnection(connectionString);

        }
            

        public List<SportProduct> GetAllProducts() //получение продуктов
        {

            List<SportProduct> products= new List<SportProduct>();
  

             sqlConnection.Open(); //открываем соединение с БД
            SqlDataReader sqlReader = null; //получаем содержимое БД,SqlDataReader позволяет получать таблицу в табличном представлении,
            SqlCommand command = new SqlCommand("SELECT * FROM [Products]", sqlConnection); //Пишем запрос, * позволяет или говорят нам, что мы будем считывать все колонки во всех строках, 2 парамметром передаем наше соединение в наш экземпляр класса

            //Обработчик исключений
            try
            {
                sqlReader =  command.ExecuteReader(); //ExecuteReaderAsync считывает таблицу
                while (sqlReader.Read())
                {
                    SportProduct product = new SportProduct()
                    {
                        ID = Convert.ToInt32(sqlReader["ID"]),  
                        Name = Convert.ToString(sqlReader["Name"]),
                        Price = Convert.ToDecimal(sqlReader["Price"])
                    };

                    products.Add(product);                 
                }
            }
            catch (Exception ex)
            {
                return null;
            }
      
            return products;
        }


        public void AddNewProduct(string tb1,string tb2)
        {

            SqlCommand command = new SqlCommand("INSERT INTO [Products] (Name,Price)VALUES(@Name,@Price)", sqlConnection);

            sqlConnection.Open(); //открываем соединение с БД
            
                command.Parameters.AddWithValue("Name", tb1);
                command.Parameters.AddWithValue("Price",tb2);
                command.ExecuteNonQuery();        

        }

        public void Update(string tb1, string tb2,string tb3)
        {

            SqlCommand command = new SqlCommand("UPDATE [Products] SET [Name] = @Name, [Price]=@Price WHERE [ID]=@ID", sqlConnection);
            sqlConnection.Open(); //открываем соединение с БД
            command.Parameters.AddWithValue("ID", tb1);
            command.Parameters.AddWithValue("Name", tb2);
            command.Parameters.AddWithValue("Price", tb3);

            command.ExecuteNonQuery();
      
        }

        public void Delete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [Products] WHERE [Id]=@Id", sqlConnection);
            sqlConnection.Open();
            command.Parameters.AddWithValue("Id", id);
            command.ExecuteNonQuery();

        }



       


    }
}
