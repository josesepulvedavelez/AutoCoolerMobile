using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoolerMobile
{
    public class AppConfig
    {
        public static string ApiBaseUrl { get; private set; }

        public static void Load()
        {
            using var stream = FileSystem.OpenAppPackageFileAsync("appsettings.json").Result;
            using var reader = new StreamReader(stream);

            var json = reader.ReadToEnd();
            var data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            ApiBaseUrl = data["ApiBaseUrl"];
        }
    }
}
