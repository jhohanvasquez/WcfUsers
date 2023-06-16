using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace WcfClient.Common
{
    public static class Util
    {
        private static IServiceProvider serviceProvider { get; set; }

        public static void Initial()
        {
            serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
        }


        public static string LoginApi(string username, string password)
        {
            string token = string.Empty;
            Initial();
            try
            {
                var client = serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient();
                var content = $"{{\"Username\":\"{username}\",\"password\":\"{password}\"}}";
                var response = client
                    .PostAsync("http://localhost:49220/api/login/authenticate", new StringContent(content, Encoding.UTF8, "application/json"))
                    .ConfigureAwait(false).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    token = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                }
                return token;
            }
            catch (Exception ex)
            {
                return token;
            }
        }

        public static void LogInsert(string description)
        {
            var token = LoginApi("user", "123456");
            Initial();
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    var client = serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var response = client
                        .GetAsync($"http://localhost:49220/api/Logs?description={description}")
                        .ConfigureAwait(false).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }           
        }
    }
}