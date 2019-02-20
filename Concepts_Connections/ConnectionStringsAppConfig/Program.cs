using System;
using System.Configuration;

// Использование файлов конфигурации позволяет изолировать информацию о подключении 
// от остальной части приложения 

namespace CBS.ADO_NET.ConnectionStringConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            // Объект ConnectionStringSettings представляет собой отдельную строку подключения в разделе строк подключения 
            // конфигурационного файла
            var setting = new ConnectionStringSettings
            {
                Name = "MyConnectionString1",     //имя строки подключения в конфигурационном файле
                ConnectionString = @"Data Source=.\SQLEXPRESS;
                                     Initial Catalog=ShopDB;
                                     Integrated Security=True;"
            };

            Configuration config;  // Объект Config представляет конфигурационный файл
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);  // Объект ConfigurationManager предоставляет доступ к файлам конфигурации
            config.ConnectionStrings.ConnectionStrings.Add(setting);
            config.Save();

            Console.WriteLine("Строка подключения записана в конфигурационный файл.");

            // Получение строки подключения.
            Console.WriteLine(ConfigurationManager.ConnectionStrings["MyConnectionString1"].ConnectionString);
        }
    }
}
