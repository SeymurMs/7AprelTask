using Newtonsoft.Json;
using System;
using System.IO;

namespace _7AprelTask
{
    internal class Program
        
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\Users\tu7mxp4w4\Desktop\7AprelTask-main\7AprelTask\7AprelTask\";
            if (!Directory.Exists(directoryPath + "Files"))
            {
                Directory.CreateDirectory(directoryPath + @"Files");
            }
            if (!File.Exists(directoryPath + @"Files\Database.json"))
            {
                File.Create(directoryPath + @"Files\Database.json");
            }
            Library library = new Library()
            {
                Name = "Seymur Lib",
                Id = 1
            };




            bool check = true;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Get book by id");
                Console.WriteLine("3. Remove book");
                Console.WriteLine("0. Quit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        bool IsId = true;
                        Console.WriteLine("Id`ni daxil edin:");
                        string idStr = Console.ReadLine();
                        int id;
                        IsId = int.TryParse(idStr, out id);
                        while (!IsId)
                        {
                            Console.WriteLine("Id`ni daxil edin:");
                            idStr = Console.ReadLine();
                            IsId = int.TryParse(idStr, out id);
                        }
                        Console.WriteLine("Kitabin Abini daxil edin:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Kitabin Yazicisini daxil edin:");
                        string authorName = Console.ReadLine();
                        Console.WriteLine("Qiymeti Daxil edin");
                        string priceStr = Console.ReadLine();
                        bool IsPrice;
                        double price;
                        IsPrice = double.TryParse(priceStr, out price);
                        while (!IsPrice)
                        {
                            Console.WriteLine("Qiymeti Daxil edin");
                            priceStr = Console.ReadLine();
                            IsPrice = double.TryParse(priceStr, out price);

                        }
                        Book book = new Book(id, name, authorName, price);
                        library.AddBook(book);
                        string JsonStr = JsonConvert.SerializeObject(library);
                        using (StreamWriter sw = new StreamWriter(directoryPath + @"Files\Database.json"))
                        {
                            sw.Write(JsonStr);

                        }
                        DateTime LastAccessTime = File.GetLastAccessTime(directoryPath + @"Files\Database.json");
                        break;
                    case "2":
                        Console.WriteLine("Id Daxil edin:");
                        string searchIdStr = Console.ReadLine();
                        int searchId;
                        IsId = int.TryParse(searchIdStr, out searchId);
                        while (!IsId)
                        {
                            Console.WriteLine("Id Daxil edin:");
                            searchIdStr = Console.ReadLine();
                            IsId = int.TryParse(searchIdStr, out searchId);
                        }
                        string JsonStrRead;
                        using (StreamReader sr = new StreamReader(directoryPath + @"Files\Database.json"))
                        {
                            JsonStrRead = sr.ReadToEnd();

                        }
                        Library libraryDeSerialize = JsonConvert.DeserializeObject<Library>(JsonStrRead);
                        foreach (var item in libraryDeSerialize.books)
                        {
                            Console.WriteLine(item.Id);
                        }
                        LastAccessTime = File.GetLastAccessTime(directoryPath + @"Files\Database.json");

                        libraryDeSerialize.GetBookById(searchId);
                        Console.WriteLine(LastAccessTime);
                        break;
                    case "3":
                        string Json;
                        Console.WriteLine("Id Daxil edin:");
                        searchIdStr = Console.ReadLine();
                        IsId = int.TryParse(searchIdStr, out searchId);
                        while (!IsId)
                        {
                            Console.WriteLine("Id Daxil edin:");
                            searchIdStr = Console.ReadLine();
                            IsId = int.TryParse(searchIdStr, out searchId);
                        }
                        using (StreamReader sr = new StreamReader(directoryPath + @"Files\Database.json"))
                        {
                            Json = sr.ReadToEnd();

                        }
                        library = JsonConvert.DeserializeObject<Library>(Json);
                        LastAccessTime = File.GetLastAccessTime(directoryPath + @"Files\Database.json");
                        library.RemoveBook(searchId);
                        
                        string JsonStrA = JsonConvert.SerializeObject(library);
                        Console.WriteLine(LastAccessTime);
                        using (StreamWriter sr = new  StreamWriter(directoryPath + @"Files\Database.json"))
                        {
                            sr.Write(JsonStrA);
                        }

                        break;
                    case "0":
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Bele emeliyyat yoxdur");
                        break;
                }
            } while (check);
        }
    }
}
