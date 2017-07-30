using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Vecc.QuickResponseCodes.Abstractions;

namespace Vecc.QuickResponseCodes.ApiClient
{
    public class ApiClient : IQuickResponseCodeGenerator
    {
        public static ErrorToleranceLevel DefaultErrorToleranceLevel = ErrorToleranceLevel.VeryLow;
        public static CodeImageFormat DefaultImageFormat = CodeImageFormat.Png;

        private static readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
                                                                                 {
                                                                                     Formatting = Formatting.Indented,
                                                                                     DefaultValueHandling = DefaultValueHandling.Include,
                                                                                     NullValueHandling = NullValueHandling.Include,
                                                                                     TypeNameHandling = TypeNameHandling.None
                                                                                 };
        private readonly IOptions<ApiClientOptions> _apiClientOptions;
        private readonly IUtilities _validator;

        public ApiClient(IOptions<ApiClientOptions> apiClientOptions, IUtilities validator)
        {
            this._apiClientOptions = apiClientOptions;
            this._validator = validator;
        }

        public Task<byte[]> GetQuickResponseCodeAsync(string data,
                                                      ErrorToleranceLevel errorToleranceLevel = ErrorToleranceLevel.VeryLow,
                                                      CodeImageFormat imageFormat = CodeImageFormat.Png,
                                                      int dimensions = 100,
                                                      int border = 4,
                                                      Color backgroundColor = null,
                                                      Color foregroundColor = null)
        {
            var bytes = Encoding.ASCII.GetBytes(data);

            return this.GetQuickResponseCodeAsync(bytes, errorToleranceLevel, imageFormat, dimensions, border, backgroundColor, foregroundColor);
        }

        public async Task<byte[]> GetQuickResponseCodeAsync(byte[] data,
                                                            ErrorToleranceLevel errorToleranceLevel = ErrorToleranceLevel.VeryLow,
                                                            CodeImageFormat imageFormat = CodeImageFormat.Png,
                                                            int dimensions = 100,
                                                            int border = 4,
                                                            Color backgroundColor = null,
                                                            Color foregroundColor = null)
        {
            if (!this._validator.DataFitsWithErrorCorrection(data, errorToleranceLevel))
            {
                throw new Exception("Data is too long for requested error tolerance.");
            }

            var request = new Models.GetQuickResponseCodeRequest(data, errorToleranceLevel,
                                                                 imageFormat,
                                                                 dimensions,
                                                                 border,
                                                                 backgroundColor,
                                                                 foregroundColor);

            var client = new HttpClient
                         {
                             BaseAddress = new Uri(this._apiClientOptions.Value.RootUrl)
                         };

            var content = JsonConvert.SerializeObject(request, _jsonSerializerSettings);

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("V1", stringContent);
            var result = await responseMessage.Content.ReadAsByteArrayAsync();

            return result;
        }
    }
}
