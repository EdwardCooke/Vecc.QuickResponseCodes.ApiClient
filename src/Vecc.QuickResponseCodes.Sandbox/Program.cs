using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Vecc.QuickResponseCodes.Abstractions;

namespace Vecc.QuickResponseCodes.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new ApiClient.ApiClientOptions()
                          {
                 RootUrl = "http://localhost:51979"
                          };
            var optionsWrapper = new OptionsWrapper<ApiClient.ApiClientOptions>(options);
            var utilities = new ApiClient.Utilities();

            var apiClient = new ApiClient.ApiClient(optionsWrapper, utilities);
            var x = Task.Run(async () =>
                     {
                         var bytes = await apiClient.GetQuickResponseCodeAsync("testing123 - api", backgroundColor: Colors.White);
                         System.IO.File.WriteAllBytes(@"C:\data\apiqr.png", bytes);
                     });

            Console.ReadLine();
        }
    }
}
