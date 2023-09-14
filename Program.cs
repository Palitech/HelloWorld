using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HelloWorld
{
    public class Program
    {
        static void Main(string[] args)
        {

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DataContextDapper dapper = new DataContextDapper(config);

            //string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //    Motherboard,
            //    HasWifi,
            //    HasLTE,
            //    ReleaseDate,
            //    Price,
            //    VideoCard
            //) VALUES ('" + myComputer.Motherboard
            //    + "','" + myComputer.HasWifi
            //    + "','" + myComputer.HasLTE
            //    + "','" + myComputer.ReleaseDate
            //    + "','" + myComputer.Price
            //    + "','" + myComputer.VideoCard
            //+ "')";

            //File.WriteAllText("log.txt", "\n" + sql + "\n";
            //using StreamWriter openFile = new("log.txt", append: true);
            //openFile.WriteLine(sql + "\n");

            //openFile.Close();

            //Console.WriteLine(File.ReadAllText("log.txt"));
            string computersJson = File.ReadAllText("ComputersSnake.json");

            //Mapper mapper = new Mapper(new MapperConfiguration((cfg) =>
            //{
            //    cfg.CreateMap<ComputerSnake, Computer>()
            //    .ForMember(destination => destination.ComputerId, options =>
            //        options.MapFrom(source => source.computer_id))
            //    .ForMember(destination => destination.CPUCores, options =>
            //        options.MapFrom(source => source.cpu_cores))
            //    .ForMember(destination => destination.HasLTE, options =>
            //        options.MapFrom(source => source.has_lte))
            //    .ForMember(destination => destination.HasWifi, options =>
            //        options.MapFrom(source => source.has_wifi))
            //    .ForMember(destination => destination.Motherboard, options =>
            //        options.MapFrom(source => source.motherboard))
            //    .ForMember(destination => destination.ReleaseDate, options =>
            //        options.MapFrom(source => source.release_date))
            //    .ForMember(destination => destination.VideoCard, options =>
            //        options.MapFrom(source => source.video_card))
            //    .ForMember(destination => destination.Price, options =>
            //        options.MapFrom(source => source.price));
            //}));

            //Console.WriteLine(computersJson);

            //JsonSerializerOptions options = new JsonSerializerOptions()
            //{
            //    //PropertyNameCaseInsensitive = true
            //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            //};

            //IEnumerable<Computer>? computersNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            IEnumerable<Computer>? computersSystemJsonPropertyMapping = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);
            if (computersSystemJsonPropertyMapping != null)
            {
                foreach (Computer computer in computersSystemJsonPropertyMapping)
                {
                    Console.WriteLine(computer.Motherboard);
                }
            }

            //if (computersSystem != null )
            //{
            //    IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computersSystem);
            //    foreach (Computer computer in computerResult)
            //    {
            //        Console.WriteLine(computer.Motherboard);
            //    }
            //}

            //if (computersNewtonSoft != null)
            //{
            //    foreach( Computer computer in computersNewtonSoft)
            //    {
            //        //Console.WriteLine(computer.Motherboard);
            //        string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //            Motherboard,
            //            HasWifi,
            //            HasLTE,
            //            ReleaseDate,
            //            Price,
            //            VideoCard
            //        ) VALUES ('" + EscapeSingleQuote(computer.Motherboard)
            //            + "','" + computer.HasWifi
            //            + "','" + computer.HasLTE
            //            + "','" + computer.ReleaseDate
            //            + "','" + computer.Price
            //            + "','" + EscapeSingleQuote(computer.VideoCard)
            //        + "')";

            //        dapper.ExecuteSql(sql);
            //    }
            //}

            //JsonSerializerSettings settings = new JsonSerializerSettings()
            //{
            //    ContractResolver = new CamelCasePropertyNamesContractResolver()
            //};
            //string computersCopyNewtonSoft = JsonConvert.SerializeObject(computersNewtonSoft, settings);

            //File.WriteAllText("computersCopyNewtonSoft.txt", computersCopyNewtonSoft);

            //string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);

            //File.WriteAllText("computersCopySystem.txt", computersCopySystem);

        }

        static string EscapeSingleQuote(string input)
        {
            string output = input.Replace("'", "''");
            return output;
        }

    }
}
