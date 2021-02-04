using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Http;

namespace EnglishSharp.filesys
{
    class Package
    {
        public static ResultStatus Download(string name)
        {
            var httpClient = new HttpClient();
            string request = $"{{\"name\":\"{name}\"}}";

            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(SuperSecret.PackageServerURL, content).Result;

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string res = result.Content.ReadAsStringAsync().Result;
                if (res == "notfound")
                    return new ResultStatus(Status.TransfileError, $"Can't find the package '{name}'");

                string target_file = $"target\\{name}.cs";

                if (!File.Exists(target_file))
                {
                    Directory.CreateDirectory("target");
                    File.Create(target_file);
                }
                File.WriteAllText(target_file, res);

                return new ResultStatus(Status.Success, "");
            }

            return new ResultStatus(Status.TransfileError, $"Can't connect to download server");
        }
    }
}