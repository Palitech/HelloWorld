using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    public class Program
    {
        static void Main(string[] args)
        {

            Computer myComputer = new Computer()
            {
                Motherboard = "TJZ997",
                HasLTE = true,
                HasWifi = false,
                ReleaseDate = DateTime.Now,
                Price = 986.45m,
                VideoCard = "RTX 3080ti"
            };


            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES ('" + myComputer.Motherboard
                + "','" + myComputer.HasWifi
                + "','" + myComputer.HasLTE
                + "','" + myComputer.ReleaseDate
                + "','" + myComputer.Price
                + "','" + myComputer.VideoCard
            + "')";

            //File.WriteAllText("log.txt", "\n" + sql + "\n";
            using StreamWriter openFile = new("log.txt", append: true);
            openFile.WriteLine(sql + "\n");

            openFile.Close();

            Console.WriteLine(File.ReadAllText("log.txt"));
  

            
        }
    }
}
