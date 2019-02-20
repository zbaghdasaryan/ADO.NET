using System;
using System.Data.SqlClient;

namespace CBS.ADO_NET.ConnectionUsing
{
    class Program
    {
        static void Connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            SqlConnection connection = sender as SqlConnection;

            Console.WriteLine();

            Console.WriteLine                 //вывод информации о соединении и его состоянии
                (
                "Connection to" + Environment.NewLine +
                "Data Source: " + connection.DataSource + Environment.NewLine +
                "Database: " + connection.Database + Environment.NewLine +
                "State: " + connection.State
                );
        }

        static void Main(string[] args)
        {
            string conStr = @"Data Source=DESKTOP-DTQ5Q8H;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;
                                Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; //строка подключения

            // для указания базы данных, к котрой нужно подключиться кроме параметра Initial Catalog можно пользоваться параметром DataBase, 

            using (SqlConnection connection = new SqlConnection(conStr))
            // при использовании объекта SqlConnection  в блоке using можно не заботиться о закрытии физического соединения с источником данных,
            // даже если в блоке using генерируется исключительная ситуация
            {
                connection.StateChange += Connection_StateChange; // событие, вызываемое при изменении состояния соединения

                try
                {
                    connection.Open();
                    //throw new Exception("error"); // раскомментировать
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } // connection.Dispose();
        }

    }
}
